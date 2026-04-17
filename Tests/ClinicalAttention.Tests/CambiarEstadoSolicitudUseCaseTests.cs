using Moq;
using Xunit;
using ClinicalAttention.Application.UseCases.Solicitudes;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;
using System;

namespace ClinicalAttention.Tests
{
    public class CambiarEstadoSolicitudUseCaseTests
    {
        private readonly Mock<ISolicitudRepository> _solicitudRepoMock;
        private readonly Mock<IHistorialRepository> _historialRepoMock;
        private readonly CambiarEstadoSolicitudUseCase _useCase;

        public CambiarEstadoSolicitudUseCaseTests()
        {
            _solicitudRepoMock = new Mock<ISolicitudRepository>();
            _historialRepoMock = new Mock<IHistorialRepository>();
            _useCase = new CambiarEstadoSolicitudUseCase(_solicitudRepoMock.Object, _historialRepoMock.Object);
        }

        [Fact]
        public async Task Ejecutar_CambiarEstadoCorrectamente()
        {
            // Arrange
            var solicitudId = Guid.NewGuid();
            var solicitud = new SolicitudAtencion(Guid.NewGuid(), "Cardiología", "Dolor en el pecho", "ALTA");

            _solicitudRepoMock.Setup(x => x.GetByIdAsync(solicitudId)).ReturnsAsync(solicitud);

            // Act
            await _useCase.Ejecutar(solicitudId, EstadoSolicitud.EN_REVISION.ToString(), "Revisión inicial");

            // Assert
            Assert.Equal("EN_REVISION", solicitud.Estado.ToString());
            _solicitudRepoMock.Verify(repo => repo.UpdateAsync(solicitud), Times.Once);
            _historialRepoMock.Verify(repo => repo.AddAsync(It.IsAny<HistorialSolicitud>()), Times.Once);
        }

        [Fact]
        public async Task Ejecutar_NoEncontrarSolicitud_ThrowException()
        {
            // Arrange
            var solicitudId = Guid.NewGuid();
            _solicitudRepoMock.Setup(x => x.GetByIdAsync(solicitudId)).ReturnsAsync((SolicitudAtencion)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _useCase.Ejecutar(solicitudId, EstadoSolicitud.EN_REVISION.ToString(), "Revisión inicial"));
        }
    }
}