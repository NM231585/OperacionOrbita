using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciónOrbita
{
    public class EstacionSensores : RecursoExploracion
    {
        public int CantidadSensores { get; private set; }
        public double ConsumoEnergetico { get; private set; }
        public decimal CostoDiario { get; private set; }

        public EstacionSensores(int id, string codigo, string modelo, int sensores, double consumo, decimal costoDiario)
            : base(id, codigo, modelo)
        {
            CantidadSensores = sensores;
            ConsumoEnergetico = consumo;
            CostoDiario = costoDiario;
        }

        public override decimal CalcularCostoOperacion(int dias)
        {
            return CostoDiario * dias;
        }
    }
}
