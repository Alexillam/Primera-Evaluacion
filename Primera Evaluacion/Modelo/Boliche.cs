using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Modelo
{
    //Clase derivada BOLICHE
    //que hereda de la clase ACTIVIDAD
    public class Boliche : Actividad
    {
        //Propiedad especifica que guarda el numero de la pista
        public int NumeroPistas { get; set; }

        //La implementacion del metodo abstracto de la clase base
        public override bool ValidarInfrmacion()
        {
            //La pista debe ser obviamente mayor a 0 
            return NumeroPistas > 0;
        }
    }
}
