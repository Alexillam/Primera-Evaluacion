using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Primera_Evaluacion.Modelo;
using Primera_Evaluacion.Negocio;

namespace Primera_Evaluacion
{
    public partial class Form1 : Form
    {
        //Este permite registrar y consultar actvidades
        private ActividadNegocio negocio = new ActividadNegocio();
        public Form1()
        {
            InitializeComponent();

            //Cargamos los tipos de actividad en el combobox
            cmbTipo.Items.Add("Cine");
            cmbTipo.Items.Add("Boliche");
            cmbTipo.Items.Add("Videojuegos");

            //Seleccionamos el primer elementos
            cmbTipo.SelectedIndex = 0;

            //Configuramos las columnas del DataGridView
            ConfigurarTabla();
        }

        //Metodo para configurarla
        private void ConfigurarTabla()
        {
            //Limpiamos las columnas 
            dgvActividades.Columns.Clear();

            // Agregamos columna para el ID
            dgvActividades.Columns.Add("Id", "Id");

            // Agregamos columna para el nombre
            dgvActividades.Columns.Add("Nombre", "Nombre");

            // Agregamos columna para el tipo
            dgvActividades.Columns.Add("Tipo", "Tipo de actividad");

            // Agregamos columna para el costo
            dgvActividades.Columns.Add("Costo", "Costo");

            // Agregamos columna para el responsable
            dgvActividades.Columns.Add("Responsable", "Responsable");

            // Agregamos columna para el teléfono
            dgvActividades.Columns.Add("Telefono", "Teléfono");

            // Agregamos columna para la característica específica
            dgvActividades.Columns.Add(
                "Caracteristica",
                "Característica");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiamos el texto del Label dependiendo
            // del tipo seleccionado

            if (cmbTipo.Text == "Cine")
            {
                // Para Cine solicitamos la sala.
                lblCaracteristica.Text = "Sala:";
            }
            else if (cmbTipo.Text == "Boliche")
            {
                // Para Boliche solicitamos las pistas.
                lblCaracteristica.Text = "Número de pistas:";
            }
            else
            {
                // Para Videojuegos solicitamos la consola.
                lblCaracteristica.Text = "Consola principal:";
            }
        }
        // EVENTO DEL BOTÓN AGREGAR.

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Primero limpiamos los errores anteriores.
            errorProvider1.Clear();

            // VARIABLE PARA SABER SI EXISTE ALGÚN ERROR.
            bool hayError = false;

            // VALIDACIÓN DEL NOMBRE.
            if (string.IsNullOrWhiteSpace(ucActividad1.Nombre))
            {
                // Mostramos ErrorProvider en caso de que esté vacío.
                errorProvider1.SetError(
                    ucActividad1,
                    "El nombre es obligatorio.");

                hayError = true;
            }

            // VALIDACIÓN DEL RESPONSABLE
            if (string.IsNullOrWhiteSpace(ucActividad1.Responsable))
            {
                errorProvider1.SetError(
                    ucActividad1,
                    "El responsable es obligatorio.");

                hayError = true;
            }

            // VALIDACIÓN DEL TELÉFONO.
            if (string.IsNullOrWhiteSpace(ucActividad1.Telefono))
            {
                errorProvider1.SetError(
                    ucActividad1,
                    "El teléfono es obligatorio.");

                hayError = true;
            }

            // VALIDACIÓN DEL COSTO.
            decimal costo;

            if (!decimal.TryParse(ucActividad1.Costo, out costo))
            {
                // Si el usuario no escribió un número.
                errorProvider1.SetError(
                    ucActividad1,
                    "El costo debe ser numérico.");

                hayError = true;
            }
            else if (costo <= 0)
            {
                // Si el costo es cero o negativo.
                errorProvider1.SetError(
                    ucActividad1,
                    "El costo debe ser mayor que cero.");

                hayError = true;
            }

            // SI EXISTE ALGÚN ERROR,
            // impedimos que continúe el registro.
            if (hayError)
            {
                MessageBox.Show(
                    "Corrige los errores antes de registrar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // CREAMOS EL OBJETO RESPONSABLE.
            Responsable responsable = new Responsable();

            // Asignamos el nombre capturado.
            responsable.Nombre = ucActividad1.Responsable;

            // Asignamos el teléfono capturado.
            responsable.Telefono = ucActividad1.Telefono;

            // VARIABLE PARA GUARDAR LA ACTIVIDAD.
            Actividad actividad;

            // DEPENDIENDO DEL TIPO SE CREA
            // UNA CLASE DIFERENTE.

            if (cmbTipo.Text == "Cine")
            {
                // Creamos un objeto Cine.
                Cine cine = new Cine();

                // Asignamos las propiedades comunes.
                cine.Nombre = ucActividad1.Nombre;
                cine.Costo = costo;

                // Asignamos el responsable.
                cine.Responsable = responsable;

                // Intentamos convertir la característica a número.
                int sala;

                if (!int.TryParse(lblCaracteristica.Text, out sala))
                {
                    MessageBox.Show(
                        "La sala debe ser un número.");

                    return;
                }

                // Asignamos la sala.
                cine.Sala = sala;

                // Guardamos el objeto como Actividad.
                actividad = cine;
            }
            else if (cmbTipo.Text == "Boliche")
            {
                // Creamos un objeto Boliche.
                Boliche boliche = new Boliche();

                // Asignamos propiedades comunes.
                boliche.Nombre = ucActividad1.Nombre;
                boliche.Costo = costo;

                // Asignamos responsable.
                boliche.Responsable = responsable;

                // Convertimos el número de pistas.
                int pistas;

                if (!int.TryParse(
                   lblCaracteristica.Text,
                    out pistas))
                {
                    MessageBox.Show(
                        "El número de pistas debe ser un número.");

                    return;
                }

                // Asignamos el número de pistas.
                boliche.NumeroPistas = pistas;

                // Guardamos como Actividad.
                actividad = boliche;
            }
            else
            {
                // Creamos un objeto Videojuegos.
                Videojuegos videojuegos = new Videojuegos();

                // Asignamos propiedades comunes.
                videojuegos.Nombre = ucActividad1.Nombre;
                videojuegos.Costo = costo;

                // Asignamos responsable.
                videojuegos.Responsable = responsable;

                // Asignamos la consola.
                videojuegos.ConsolaPrincipal =
                    lblCaracteristica.Text;

                // Guardamos como Actividad.
                actividad = videojuegos;
            }

            // TRY-CATCH
            // Utilizamos manejo de excepciones para controlar
            // errores que puedan ocurrir durante el registro.
            try
            {
                // Enviamos la actividad a la capa Negocio.
                negocio.Registrar(actividad);

                // Mostramos mensaje de confirmación.
                MessageBox.Show(
                    "Actividad registrada correctamente.",
                    "Registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiamos los datos.
                ucActividad1.Limpiar();

                lblCaracteristica.Clear();
            }
            catch (CostoInvalidoException ex)
            {
                // CAPTURAMOS NUESTRA EXCEPCIÓN PERSONALIZADA.
                MessageBox.Show(
                    ex.Message,
                    "Costo inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                // CAPTURAMOS UNA EXCEPCIÓN DEL SISTEMA.
                MessageBox.Show(
                    ex.Message,
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // CAPTURAMOS CUALQUIER OTRO ERROR NO PREVISTO.
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            {
                // Primero limpiamos las filas actuales.
                dgvActividades.Rows.Clear();

                // Recuperamos todas las actividades
                // desde la capa Negocio.
                var actividades = negocio.ObtenerActividades();

                // RECORREMOS LA LISTA
                // utilizando un ciclo foreach.
                foreach (Actividad actividad in actividades)
                {
                    // Variable para guardar el tipo.
                    string tipo = "";

                    // Variable para guardar la característica.
                    string caracteristica = "";

                    // IDENTIFICAMOS EL TIPO DE OBJETO.
                    if (actividad is Cine cine)
                    {
                        tipo = "Cine";

                        // Obtenemos la sala.
                        caracteristica = cine.Sala.ToString();
                    }
                    else if (actividad is Boliche boliche)
                    {
                        tipo = "Boliche";

                        // Obtenemos el número de pistas.
                        caracteristica =
                            boliche.NumeroPistas.ToString();
                    }
                    else if (actividad is Videojuegos videojuegos)
                    {
                        tipo = "Videojuegos";

                        // Obtenemos la consola.
                        caracteristica =
                            videojuegos.ConsolaPrincipal;
                    }

                    // AGREGAMOS LA INFORMACIÓN AL DATAGRIDVIEW.
                    dgvActividades.Rows.Add(
                        actividad.Id,
                        actividad.Nombre,
                        tipo,
                        actividad.Costo,
                        actividad.Responsable.Nombre,
                        actividad.Responsable.Telefono,
                        caracteristica);
                }
            }
        }
    }
}


