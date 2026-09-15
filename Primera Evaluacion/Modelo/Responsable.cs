using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Modelo
{
    //Esta clase representa a la personsa resposable de la actividad
    //Se utilizara para implementar la relacion HAS-A
    public class Responsable
    {
        //Atributo nombre
        //Este guarda el nombre del responsable
        public string Nombre { get; set; }

        //Atributo telefono
        //Guarda el telefono del responsable
        public string Telefono { get; set; }
    }
}
