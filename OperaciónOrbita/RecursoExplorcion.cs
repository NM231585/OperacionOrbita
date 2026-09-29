using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciónOrbita
{
    public abstract class RecursoExploracion : IAsignable
    {
        public int Id { get; protected set; }
        public string Codigo { get; protected set; }
        public string Modelo { get; protected set; }
        public EstadoRecurso Estado { get; protected set; }

        public RecursoExploracion(int id, string codigo, string modelo)
        {
            Id = id;
            Codigo = codigo;
            Modelo = modelo;
            Estado = EstadoRecurso.Disponible;
        }

        // Obliga a las clases hijas a definir cómo calculan su costo operativo
        public abstract decimal CalcularCostoOperacion(int unidadMedida);

        public bool ConsultarDisponibilidad()
        {
            return Estado == EstadoRecurso.Disponible;
        }

        public void AsignarMision()
        {
            if (!ConsultarDisponibilidad())
                throw new Exception($"El recurso {Codigo} no está disponible.");

            Estado = EstadoRecurso.Asignado;
        }

        public void LiberarRecurso()
        {
            Estado = EstadoRecurso.Disponible;
        }

        public override string ToString()
        {
            return $"{Codigo} | {Modelo} | {Estado}";
        }
    }
}
