using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciónOrbita
{
    public class Rover : RecursoExploracion
    {
        public double Autonomia { get; private set; }
        public double CapacidadCarga { get; private set; }
        public decimal CostoPorKilometro { get; private set; }

        public Rover(int id, string codigo, string modelo, double autonomia, double capacidad, decimal costoKm)
            : base(id, codigo, modelo)
        {
            Autonomia = autonomia;
            CapacidadCarga = capacidad;
            CostoPorKilometro = costoKm;
        }

        public override decimal CalcularCostoOperacion(int kilometros)
        {
            return CostoPorKilometro * kilometros;
        }
    }
}
