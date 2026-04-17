using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Application.UseCases.Solicitudes;
using ClinicalAttention.Application.UseCases.Common;
using ClinicalAttention.Application.DTOs;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitudesController : Controller
    {

        private readonly CrearSolicitudUseCase _crearUseCase;
        private readonly AsignarMedicoUseCase _asignarUseCase;
        private readonly ObtenerSolicitudesUseCase _obtenerUseCase;
        private readonly CambiarEstadoSolicitudUseCase _cambiarEstadoUseCase;
        private readonly ObtenerHistorialSolicitudUseCase _historialUseCase;
        private readonly TestDbUseCase _testDbUseCase;
        private readonly ILogger<SolicitudesController> _logger;

        public SolicitudesController(
            CrearSolicitudUseCase crearUseCase,
            AsignarMedicoUseCase asignarUseCase,
            ObtenerSolicitudesUseCase obtenerUseCase,
            CambiarEstadoSolicitudUseCase cambiarEstadoUseCase,
            ObtenerHistorialSolicitudUseCase historialUseCase,
            TestDbUseCase testDbUseCase,
            ILogger<SolicitudesController> logger)
        {
            _crearUseCase = crearUseCase;
            _asignarUseCase = asignarUseCase;
            _obtenerUseCase = obtenerUseCase;
            _cambiarEstadoUseCase = cambiarEstadoUseCase;
            _historialUseCase = historialUseCase;
            _testDbUseCase = testDbUseCase;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearSolicitudDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            _logger.LogInformation("Creando solicitud...");

            var solicitud = await _crearUseCase.Ejecutar(
                dto.PacienteId,
                dto.Especialidad,
                dto.Motivo,
                dto.Prioridad);

            return CreatedAtAction(nameof(ObtenerTodas), new { id = solicitud.Id }, solicitud);
        }

        [HttpGet("test-db")]
        public async Task<IActionResult> TestDb()
        {
            await _testDbUseCase.Ejecutar();
            return Ok(new { message = "DB OK" });
        }

        [HttpPost("{id}/asignar")]
        public async Task<IActionResult> AsignarMedico(Guid id)
        {
            await _asignarUseCase.Ejecutar(id);
            return Ok(new { message = "Asignado correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var solicitudes = await _obtenerUseCase.Ejecutar();
            return Ok(solicitudes);
        }

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(Guid id, [FromBody] CambiarEstadoDto dto)
        {
            await _cambiarEstadoUseCase.Ejecutar(id, dto.Estado, dto.Observacion);

            return Ok(new { message = "Estado actualizado" });
        }

        [HttpGet("{id}/historial")]
        public async Task<IActionResult> ObtenerHistorial(Guid id)
        {
            var historial = await _historialUseCase.Ejecutar(id);

            return Ok(historial);
        }

    }
}