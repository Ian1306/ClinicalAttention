using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class Medico : BaseEntity
    {
        public string Nombre { get; private set; }
        public string Especialidad { get; private set; }
        public bool Disponible { get; private set; }
        public string Estado { get; private set; } = "ACTIVO";

        public Medico(string nombre, string especialidad, bool disponible = true)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Nombre requerido");

            if (string.IsNullOrWhiteSpace(especialidad))
                throw new Exception("Especialidad requerida");

            Nombre = nombre;
            Especialidad = especialidad;
            Disponible = true;
        }

        public void MarcarComoNoDisponible() => Disponible = false;

        public void MarcarComoDisponible() => Disponible = true;
    }
}