using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MANTEMIENTO_PRODUCTO
{
    public partial class Registro_Nuevo : Form
    {
        private int idcategoria;
        private bool Editarse = false;
        Registro_NuevosE objEntidad = new Registro_NuevosE();
        Registro_NuevoN objNegocio = new Registro_NuevoN();
        public Registro_Nuevo()
        {
            InitializeComponent();
            mostrarBuscarTabla(0);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NUEVO_Click(object sender, EventArgs e)
        {
            Editarse = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacimiento.Text = "";
            txtTipo_usuario.Text = "";
            txtUsuario.Text = "";
            txtApellido.Focus();
        }

        private void EDITAR_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                idcategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[5].Value);
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtApellido.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNacimiento.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtTipo_usuario.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
                txtUsuario.Text = tablaCategoria.CurrentRow.Cells[4].Value.ToString();

                Editarse = true;

            }
            else
            {
                MessageBox.Show("Selecciona la fila que quiera editar");

            }

        }
        private void limpiar()
        {

            Editarse = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacimiento.Text = "";
            txtApellido.Focus();
        }
        public void mostrarBuscarTabla(int buscar)
        {
            Registro_NuevoN objNegocio = new Registro_NuevoN();
            tablaCategoria.DataSource = objNegocio.ListarCategoria(buscar);

        }
        private void ELIMINAR_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.Id = idcategoria;
                objEntidad.Nombre = txtNombre.Text.ToUpper();
                objEntidad.Apellido = txtApellido.Text.ToUpper();
                objEntidad.Nacimiento = txtNacimiento.Value.ToString();


                objEntidad.Tipo_usuario = txtTipo_usuario.Text.ToUpper();
                objEntidad.Usuario = txtUsuario.Text.ToUpper();
                objEntidad.Id = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[5].Value.ToString());
                objNegocio.ElimandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente los datos");
                mostrarBuscarTabla(0);
                limpiar();


            }
            else
            {
                MessageBox.Show("Seleccione la fila que quiera eliminar");
            }
        }

        private void GUARDAR_Click(object sender, EventArgs e)
        {

            if (Editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Apellido = txtApellido.Text.ToUpper();
                    objEntidad.Nacimiento = txtNacimiento.Value.ToString();
                    objEntidad.Tipo_usuario = txtTipo_usuario.Text.ToUpper();
                    objEntidad.Usuario = txtUsuario.Text.ToUpper();
                    objNegocio.InsertandoCategoria(objEntidad);

                    MessageBox.Show("Se han guardado los datos");
                    mostrarBuscarTabla(0);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar los datos" + ex);

                }

            }
            if (Editarse == true)
            {
                try
                {
                    objEntidad.Id = idcategoria;
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                       objEntidad.Apellido = txtApellido.Text.ToUpper();
                    objEntidad.Nacimiento = txtNacimiento.Value.ToString();

                    objEntidad.Tipo_usuario = txtTipo_usuario.Text.ToUpper();
                           objEntidad.Usuario = txtUsuario.Text.ToUpper();

                    objNegocio.EditandoCategoria(objEntidad);

                    MessageBox.Show("Se han editado los datos");
                    mostrarBuscarTabla(0);
                    Editarse = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar los datos" + ex);

                }

            }

            limpiar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cerrarFormulario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtHora_salida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
