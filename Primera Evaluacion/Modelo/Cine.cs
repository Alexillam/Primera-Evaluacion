using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Modelo
{
    //Clase derivada cine
    //que hereda de la clase Actividad

    public class Cine : Actividad
    {
        //Propiedad especifica
        //Que guarda el numero de la sala 
        public int Sala { get; set; }

        //La implementacion del metodo abstracto de la clase base
        //Valida la imfromacion de cine
        public override bool ValidarInfrmacion()
        {
            //La sala debe ser obviamente mayor a 0 
            return Sala > 0;
        }
    }
}
