using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinicalAttention.Domain.Entities;
using ClinicalAttention.Application.DTOs;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Application.UseCases.Medicos;

namespace ClinicalAttention.Api.Controllers
{
    [Route("[controller]")]
    public class MedicosController : Controller
    {
        private readonly CrearMedicoUseCase _crearUseCase;
        private readonly ObtenerMedicosUseCase _obtenerUseCase;
        private readonly ObtenerMedicosDisponiblesUseCase _disponiblesUseCase;

        public MedicosController(
            CrearMedicoUseCase crearUseCase,
            ObtenerMedicosUseCase obtenerUseCase,
            ObtenerMedicosDisponiblesUseCase disponiblesUseCase)
        {
            _crearUseCase = crearUseCase;
            _obtenerUseCase = obtenerUseCase;
            _disponiblesUseCase = disponiblesUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _obtenerUseCase.Ejecutar();
            return Ok(medicos);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearMedicoDto dto)
        {
            var medico = await _crearUseCase.Ejecutar(dto.Nombre, dto.Especialidad);
            return Ok(medico);
        }

        [HttpGet("disponibles")]
        public async Task<IActionResult> GetDisponibles()
        {
            var medicos = await _disponiblesUseCase.Ejecutar();
            return Ok(medicos);
        }
    }
}