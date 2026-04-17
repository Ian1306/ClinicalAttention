using Moq;
using Xunit;
using ClinicalAttention.Application.UseCases.Solicitudes;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;
using System;

namespace ClinicalAttention.Tests
{
    public class CrearSolicitudUseCaseTests
    {
        private readonly Mock<ISolicitudRepository> _repoMock;
        private readonly CrearSolicitudUseCase _useCase;

        public CrearSolicitudUseCaseTests()
        {
            _repoMock = new Mock<ISolicitudRepository>();
            _useCase = new CrearSolicitudUseCase(_repoMock.Object);
        }

        [Fact]
        public async Task Ejecutar_CrearSolicitudCorrectamente()
        {
            // Arrange
            var pacienteId = Guid.NewGuid();
            var especialidad = "Cardiología";
            var motivo = "Dolor fuerte en el pecho";
            var prioridad = "ALTA";

            // Act
            var result = await _useCase.Ejecutar(pacienteId, especialidad, motivo, prioridad);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pacienteId, result.PacienteId);
            Assert.Equal(especialidad, result.Especialidad);
            Assert.Equal(motivo, result.Motivo);
            _repoMock.Verify(repo => repo.AddAsync(It.IsAny<SolicitudAtencion>()), Times.Once);
        }
    }
}