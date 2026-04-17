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
using ClinicalAttention.Application.UseCases.Consultas;

namespace ClinicalAttention.Api.Controllers
{
    [Route("[controller]")]
    public class ConsultasController : Controller
    {
        private readonly CrearConsultaUseCase _crearUseCase;
        private readonly ObtenerConsultasUseCase _obtenerUseCase;

        public ConsultasController(
            CrearConsultaUseCase crearUseCase,
            ObtenerConsultasUseCase obtenerUseCase)
        {
            _crearUseCase = crearUseCase;
            _obtenerUseCase = obtenerUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearConsultaDto dto)
        {
            var consulta = await _crearUseCase.Ejecutar(
                dto.SolicitudId,
                dto.MedicoId,
                dto.Diagnostico,
                dto.Tratamiento
            );

            return Ok(consulta);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _obtenerUseCase.Ejecutar();
            return Ok(consultas);
        }


    }
}