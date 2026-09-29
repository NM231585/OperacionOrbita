using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciónOrbita
{
    public enum EstadoRecurso { Disponible, Asignado, Mantenimiento }
    public enum EstadoMision { Planificada, EnEjecucion, Finalizada, Cancelada }
    public enum RolUsuario { Administrador, Coordinador, Auditor }

    public interface IAsignable
    {
        void AsignarMision();
        void LiberarRecurso();
        bool ConsultarDisponibilidad();
    }
}
