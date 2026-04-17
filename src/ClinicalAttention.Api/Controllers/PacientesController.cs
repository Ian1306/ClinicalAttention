using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Application.DTOs;
using ClinicalAttention.Application.UseCases.Pacientes;
using ClinicalAttention.Domain.Entities;



namespace ClinicalAttention.Api.Controllers
{
    [Route("[controller]")]
    public class PacientesController : Controller
    {
        private readonly CrearPacienteUseCase _crearUseCase;
        private readonly ObtenerPacientesUseCase _obtenerUseCase;
        private readonly ActualizarPacienteUseCase _actualizarUseCase;

        public PacientesController(
            CrearPacienteUseCase crearUseCase,
            ObtenerPacientesUseCase obtenerUseCase,
            ActualizarPacienteUseCase actualizarUseCase)
        {
            _crearUseCase = crearUseCase;
            _obtenerUseCase = obtenerUseCase;
            _actualizarUseCase = actualizarUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _obtenerUseCase.Ejecutar();
            return Ok(pacientes);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearPacienteDto dto)
        {
            var paciente = await _crearUseCase.Ejecutar(
                dto.Nombre,
                dto.Documento,
                dto.Edad
            );

            return Ok(paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarPacienteDto dto)
        {
            var paciente = await _actualizarUseCase.Ejecutar(
                id,
                dto.Nombre,
                dto.Documento,
                dto.Edad
            );

            if (paciente == null)
                return NotFound("Paciente no encontrado");

            return Ok(paciente);
        }
    }
}