using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciónOrbita
{
    public class Dron : RecursoExploracion
    {
        public double AutonomiaVuelo { get; private set; }
        public double Alcance { get; private set; }
        public decimal CostoPorHora { get; private set; }

        public Dron(int id, string codigo, string modelo, double autonomia, double alcance, decimal costoHora)
            : base(id, codigo, modelo)
        {
            AutonomiaVuelo = autonomia;
            Alcance = alcance;
            CostoPorHora = costoHora;
        }

        public override decimal CalcularCostoOperacion(int horas)
        {
            return CostoPorHora * horas;
        }
    }
}
