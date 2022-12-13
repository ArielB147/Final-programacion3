using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

namespace MANTEMIENTO_PRODUCTO
{
    public partial class frmCategoria : Form
    {
        private int idcategoria;
        private bool Editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla(0);
        }

        private void cerrarFormulario_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void mostrarBuscarTabla(int buscar) 
        {
            N_Categoria objNegocio = new N_Categoria();
            tablaCategoria.DataSource = objNegocio.ListarCategoria(buscar);
        
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
          //  mostrarBuscarTabla(Convert.ToInt32(txtBuscar.Text));
        }
        private void limpiar() 
        {

            Editarse = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtApellido.Focus();
        }

        private void NUEVO_Click(object sender, EventArgs e)
        {
            Editarse = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtCarrera.Text = "";
            txtEdificio.Text = "";
            txtHora_entrada.Text = "";
            txtHora_salida.Text = "";
            txtMotivo.Text = "";
            txtAula.Text = "";
            txtApellido.Focus();
        }

        private void EDITAR_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count>0) 
            {
                idcategoria =  Convert.ToInt32(tablaCategoria.CurrentRow.Cells[10].Value);
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtApellido.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtCorreo.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
                txtCarrera.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtEdificio.Text = tablaCategoria.CurrentRow.Cells[4].Value.ToString();
                txtHora_entrada.Value = Convert.ToDateTime(tablaCategoria.CurrentRow.Cells[5].Value);
                txtHora_salida.Value = Convert.ToDateTime(tablaCategoria.CurrentRow.Cells[6].Value);
                txtMotivo.Text = tablaCategoria.CurrentRow.Cells[7].Value.ToString();
                txtAula.Text = tablaCategoria.CurrentRow.Cells[9].Value.ToString();


                Editarse = true;

            }
            else 
            {
                MessageBox.Show("Selecciona la fila que quiera editar");
            
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
                    objEntidad.Correo = txtCorreo.Text.ToUpper();
                    objEntidad.Carrera = txtCarrera.Text.ToUpper();
                    objEntidad.Edificio = txtEdificio.Text.ToUpper();
                    objEntidad.Hora_entrada = txtHora_entrada.Value.ToShortTimeString();
                    objEntidad.Hora_salida = txtHora_salida.Value.ToShortTimeString();
                    objEntidad.Motivo = txtMotivo.Text.ToUpper();
                    objEntidad.Aula = txtAula.Text.ToUpper();

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
                    objEntidad.Correo = txtCorreo.Text.ToUpper();
                    objEntidad.Carrera = txtCarrera.Text.ToUpper();
                    objEntidad.Edificio = txtEdificio.Text.ToUpper();
                    objEntidad.Hora_entrada = txtHora_entrada.Value.ToShortTimeString();
                    objEntidad.Hora_salida = txtHora_salida.Value.ToShortTimeString();
                    objEntidad.Motivo = txtMotivo.Text.ToUpper();
                    objEntidad.Aula = txtAula.Text.ToUpper();

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

        private void ELIMINAR_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0) 
            {
                objEntidad.Id = idcategoria;
                objEntidad.Nombre = txtNombre.Text.ToUpper();
                objEntidad.Apellido = txtApellido.Text.ToUpper();
                objEntidad.Correo = txtCorreo.Text.ToUpper();
                objEntidad.Carrera = txtCarrera.Text.ToUpper();
                objEntidad.Edificio = txtEdificio.Text.ToUpper();
                objEntidad.Hora_entrada = txtHora_entrada.Value.ToShortTimeString();
                objEntidad.Hora_salida = txtHora_salida.Value.ToShortTimeString();
                objEntidad.Motivo = txtMotivo.Text.ToUpper();
                objEntidad.Aula = txtAula.Text.ToUpper();
                objEntidad.Id = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[10].Value.ToString());
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tablaCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usuarios_nuevos_Click(object sender, EventArgs e)
        {
            Registro_Nuevo formulario = new Registro_Nuevo();
            formulario.ShowDialog();
            this.Close();
        }
    }
}
