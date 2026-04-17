using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class Receta: BaseEntity
    {
        public Guid ConsultaId { get; private set; }
        public DateTime Fecha { get; private set; }

        public Receta(Guid consultaId)
        {
            if (consultaId == Guid.Empty)
                throw new Exception("Consulta requerida");

            ConsultaId = consultaId;
            Fecha = DateTime.UtcNow;
        }
    }
}