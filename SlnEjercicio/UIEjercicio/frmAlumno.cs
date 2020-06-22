using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIEjercicio
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }
        
        private void cargarListado()
        {
            lstAlumnos.Rows.Clear();
            List<Alumno> alumnos = AlumnoBLL.List();
            lstAlumnos.DataSource = alumnos;
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                a.apellidos = txtApellido.Text.Trim();
                a.cedula = txtCedula.Text.Trim();
                a.nombres = txtNombre.Text.Trim();
                a.lugar_nacimiento = txtLugar.Text.Trim();
                a.sexo = rbMasculino.Checked ? "M" : "F";
                a.fecha_nacimiento = dtpFecha.Value;

                AlumnoBLL.Create(a);
                cargarListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
