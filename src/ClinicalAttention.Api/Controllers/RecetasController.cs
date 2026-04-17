using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Application.DTOs;
using ClinicalAttention.Domain.Entities;
using ClinicalAttention.Application.UseCases.Recetas;

namespace ClinicalAttention.Api.Controllers
{
    [Route("[controller]")]
    public class RecetasController : Controller
    {

        private readonly CrearRecetaUseCase _crearUseCase;
        private readonly ObtenerRecetaPorIdUseCase _obtenerUseCase;

        public RecetasController(
            CrearRecetaUseCase crearUseCase,
            ObtenerRecetaPorIdUseCase obtenerUseCase)
        {
            _crearUseCase = crearUseCase;
            _obtenerUseCase = obtenerUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearRecetaDto dto)
        {
            var receta = await _crearUseCase.Ejecutar(dto.ConsultaId);

            return Ok(receta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var receta = await _obtenerUseCase.Ejecutar(id);

            if (receta == null)
                return NotFound("Receta no encontrada");

            return Ok(receta);
        }

    }
}