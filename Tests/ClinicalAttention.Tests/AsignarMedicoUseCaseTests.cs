using Moq;
using Xunit;
using ClinicalAttention.Application.UseCases.Solicitudes;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;
using System;

namespace ClinicalAttention.Tests
{
    public class AsignarMedicoUseCaseTests
    {
        private readonly Mock<ISolicitudRepository> _solicitudRepoMock;
        private readonly Mock<IMedicoRepository> _medicoRepoMock;
        private readonly AsignarMedicoUseCase _useCase;

        public AsignarMedicoUseCaseTests()
        {
            _solicitudRepoMock = new Mock<ISolicitudRepository>();
            _medicoRepoMock = new Mock<IMedicoRepository>();
            _useCase = new AsignarMedicoUseCase(_solicitudRepoMock.Object, _medicoRepoMock.Object);
        }

        [Fact]
        public async Task Ejecutar_SolicitudAsignadaCorrectamente()
        {
            // Arrange
            var solicitudId = Guid.NewGuid();
            var solicitud = new SolicitudAtencion(Guid.NewGuid(), "Cardiología", "Dolor en el pecho", "ALTA");
            var medico = new Medico("Dr. Pérez", "Cardiología");

            _solicitudRepoMock.Setup(x => x.GetByIdAsync(solicitudId)).ReturnsAsync(solicitud);
            _medicoRepoMock.Setup(x => x.GetDisponiblePorEspecialidadAsync("Cardiología")).ReturnsAsync(medico);

            // Act
            await _useCase.Ejecutar(solicitudId);

            // Assert
            Assert.Equal(medico.Id, solicitud.MedicoAsignadoId); // 🔥 FIX
            _solicitudRepoMock.Verify(repo => repo.UpdateAsync(solicitud), Times.Once);
            _medicoRepoMock.Verify(repo => repo.UpdateAsync(medico), Times.Once);
        }

        [Fact]
        public async Task Ejecutar_NoEncontrarSolicitud_ThrowException()
        {
            // Arrange
            var solicitudId = Guid.NewGuid();
            _solicitudRepoMock.Setup(x => x.GetByIdAsync(solicitudId)).ReturnsAsync((SolicitudAtencion)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _useCase.Ejecutar(solicitudId));
        }

        [Fact]
        public async Task Ejecutar_NoMedicoDisponible_ThrowException()
        {
            // Arrange
            var solicitudId = Guid.NewGuid();
            var solicitud = new SolicitudAtencion(Guid.NewGuid(), "Cardiología", "Dolor en el pecho", "ALTA");

            _solicitudRepoMock.Setup(x => x.GetByIdAsync(solicitudId)).ReturnsAsync(solicitud);
            _medicoRepoMock.Setup(x => x.GetDisponiblePorEspecialidadAsync("Cardiología")).ReturnsAsync((Medico)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _useCase.Ejecutar(solicitudId));
        }
    }
}