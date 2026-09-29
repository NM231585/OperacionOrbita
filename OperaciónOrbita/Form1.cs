using OperaciónOrbita.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace OperaciónOrbita
{
    public partial class FrmLogin : Form
    {
        public static string UsuarioSesionActual = "";
        public static string RolSesionActual = "";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Instanciamos el contexto de Entity Framework
                using (OrbitaDBEntities db = new OrbitaDBEntities())
                {
                    var usuario = db.Usuarios.FirstOrDefault(u =>
                                        u.NombreUsuario == txtUsuario.Text &&
                                        u.Password == txtPassword.Text &&
                                        u.Estado == true);

                    if (usuario != null)
                    {
                        UsuarioSesionActual = usuario.NombreUsuario;
                        RolSesionActual = usuario.Rol;

                        MessageBox.Show($"Bienvenido {UsuarioSesionActual} | Nivel de Acceso: {RolSesionActual}",
                                        "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmPanelControl frmPanel = new FrmPanelControl();
                        frmPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas o el usuario se encuentra inactivo.",
                                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con la base de datos: {ex.Message}",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
