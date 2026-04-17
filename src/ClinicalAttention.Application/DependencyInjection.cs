using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ClinicalAttention.Application.UseCases.Solicitudes;
using ClinicalAttention.Application.UseCases.Common;
using ClinicalAttention.Application.UseCases.Medicos;
using ClinicalAttention.Application.UseCases.Recetas;
using ClinicalAttention.Application.UseCases.Pacientes;
using ClinicalAttention.Application.UseCases.Consultas;

namespace ClinicalAttention.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CrearSolicitudUseCase>();
        services.AddScoped<AsignarMedicoUseCase>();
        services.AddScoped<CrearPacienteUseCase>();
        services.AddScoped<ObtenerSolicitudesUseCase>();
        services.AddScoped<TestDbUseCase>();
        services.AddScoped<CrearMedicoUseCase>();
        services.AddScoped<ObtenerMedicosUseCase>();
        services.AddScoped<ObtenerMedicosDisponiblesUseCase>();
        services.AddScoped<CrearRecetaUseCase>();
        services.AddScoped<ObtenerRecetaPorIdUseCase>();
        services.AddScoped<ObtenerPacientesUseCase>();
        services.AddScoped<ActualizarPacienteUseCase>();
        services.AddScoped<CrearConsultaUseCase>();
        services.AddScoped<ObtenerConsultasUseCase>();
        services.AddScoped<CambiarEstadoSolicitudUseCase>();
        services.AddScoped<ObtenerHistorialSolicitudUseCase>();
  
        return services;
    }
}