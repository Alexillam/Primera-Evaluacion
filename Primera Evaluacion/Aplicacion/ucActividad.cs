using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primera_Evaluacion.Aplicacion
{
    //este control concentra la captura de datos que son comunes en todas las activdidades
    public partial class ucActividad : UserControl
    {
        public ucActividad()
        {
            InitializeComponent();
        }

        //Propiedad Nombre
        //ESTA PERMITE OBTENER EL TEXTO ESCRITO EN TXTNOMBRE
        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }

        //Propiedad costo
        //ESTA PERMITE OBTENER EL TEXTO ESCRITO EN TXTCOSTO
        public string Costo
        {
            get { return txtCosto.Text; }
            set { txtCosto.Text = value; }
        }

        //Propiedad responsable
        //ESTA PERMITE OBTENER EL TEXTO ESCRITO EN TXTRESPONSABLE
        public string Responsable
        {
            get { return txtResponsable.Text; }
            set { txtResponsable.Text = value; }
        }

        //Propiedad teléfono
        //ESTA PERMITE OBTENER EL TEXTO ESCRITO EN TXTTELEFONO
        public string Telefono
        {
            get { return txtTelefono.Text; }
            set { txtTelefono.Text = value; }
        }

        //Este es para limpiar el user 
        public void Limpiar()
        {
            txtNombre.Clear();
            txtCosto.Clear();
            txtResponsable.Clear();
            txtTelefono.Clear();
        }
    }
}
