using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string Nombre { get; private set; }
        public string Documento { get; private set; }
        public int Edad { get; private set; }
        public string Estado { get; private set; } = "ACTIVO";

            public Paciente(string nombre, string documento, int edad)
            {
                if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("Nombre requerido");
                if (string.IsNullOrWhiteSpace(documento)) throw new Exception("Documento requerido");

                Nombre = nombre;
                Documento = documento;
                Edad = edad;
            }
            public void Actualizar(string nombre, string documento, int edad)
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("Nombre requerido");

                if (string.IsNullOrWhiteSpace(documento))
                    throw new Exception("Documento requerido");

                if (edad <= 0)
                    throw new Exception("Edad inválida");

                Nombre = nombre;
                Documento = documento;
                Edad = edad;
            }
    }
}