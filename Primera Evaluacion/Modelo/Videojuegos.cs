using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Modelo
{
    //Clase derivada VIDEOJUEGOS de la clase base ACTIVIDAD
    public class Videojuegos : Actividad
    {
        //Propiedad especifica que guarda la consola principal 
        public string ConsolaPrincipal { get; set; }

        //La implementacion del metodo abstracto de la clase base
        public override bool ValidarInfrmacion()
        {
            //La consola no debe estar vacia 
            return !string.IsNullOrEmpty(ConsolaPrincipal);
        }
    }
}
