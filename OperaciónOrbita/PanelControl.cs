using OperaciónOrbita.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperaciónOrbita
{
    public partial class FrmPanelControl : Form
    {
        public FrmPanelControl()
        {
            InitializeComponent();
        }

        private void FrmPanelControl_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Operador: {FrmLogin.UsuarioSesionActual} | Rol: {FrmLogin.RolSesionActual}";

            CargarMisiones();
        }

        private void CargarMisiones()
        {
            try
            {
                using (OrbitaDBEntities db = new OrbitaDBEntities())
                {
                    var listaMisiones = (from m in db.Misiones
                                         join u in db.Usuarios on m.ResponsableId equals u.Id
                                         select new
                                         {
                                             Código = m.Codigo,
                                             Misión = m.Nombre,
                                             Prioridad = m.Prioridad,
                                             Inicio = m.FechaInicio,
                                             Estado = m.Estado,
                                             Responsable = u.NombreUsuario
                                         }).ToList();

                    dgvMisiones.DataSource = listaMisiones;

                    dgvMisiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}", "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarMision_Click(object sender, EventArgs e)
        {
            if (dgvMisiones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una misión de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoMision = dgvMisiones.SelectedRows[0].Cells["Código"].Value.ToString();

            try
            {
                using (OrbitaDBEntities db = new OrbitaDBEntities())
                {
                    var mision = db.Misiones.FirstOrDefault(m => m.Codigo == codigoMision);

                    if (mision == null) return;

                    if (mision.FechaFin < mision.FechaInicio)
                    {
                        throw new Exception("Error de Protocolo: La fecha de finalización no puede ser anterior a la de inicio.");
                    }

                    var asignaciones = db.Asignaciones.Where(a => a.MisionId == mision.Id).ToList();

                    if (asignaciones.Count == 0)
                    {
                        throw new Exception("Error de Protocolo: La misión no tiene recursos asignados.");
                    }

                    List<OperaciónOrbita.RecursoExploracion> listaRecursosPolimorficos = new List<OperaciónOrbita.RecursoExploracion>();

                    foreach (var asig in asignaciones)
                    {
                        var recursoBD = db.Recursos.FirstOrDefault(r => r.Id == asig.RecursoId);

                        if (recursoBD.Estado == "Mantenimiento")
                        {
                            throw new Exception($"Error de Protocolo: El recurso {recursoBD.Codigo} se encuentra en mantenimiento.");
                        }

                        if (recursoBD.Tipo == "Dron")
                        {
                            listaRecursosPolimorficos.Add(new OperaciónOrbita.Dron(recursoBD.Id, recursoBD.Codigo, recursoBD.Modelo, (double)recursoBD.Autonomia, (double)recursoBD.Alcance, (decimal)recursoBD.CostoPorHora));
                        }
                        else if (recursoBD.Tipo == "Rover")
                        {
                            listaRecursosPolimorficos.Add(new OperaciónOrbita.Rover(recursoBD.Id, recursoBD.Codigo, recursoBD.Modelo, (double)recursoBD.Autonomia, (double)recursoBD.CapacidadCarga, (decimal)recursoBD.CostoPorKilometro));
                        }
                        else if (recursoBD.Tipo == "EstacionSensores")
                        {
                            listaRecursosPolimorficos.Add(new OperaciónOrbita.EstacionSensores(recursoBD.Id, recursoBD.Codigo, recursoBD.Modelo, (int)recursoBD.CantidadSensores, (double)recursoBD.ConsumoEnergetico, (decimal)recursoBD.CostoDiario));
                        }
                    }

                    decimal costoTotalEstimado = 0;

                    foreach (var equipo in listaRecursosPolimorficos)
                    {

                        costoTotalEstimado += equipo.CalcularCostoOperacion(10);
                    }

                    MessageBox.Show($"Protocolo ORBITA superado.\nLa misión '{mision.Nombre}' está lista para iniciar.\n\nCosto Estimado de Operación: {costoTotalEstimado:C}", "Autorización Concedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Protocolo de Seguridad Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
