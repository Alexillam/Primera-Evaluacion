using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Modelo
{
    //Esta es la clase abstracta principal
    //Contiene las caracteristicas comunes de todas las actividades
    public abstract class Actividad
    {
        //Atributo ID
        //Identifica de manera unica a cada actividad
        public int Id { get; set; }

        //Atributo Nombre
        //Guarda el nombre de la actividad
        public string Nombre { get; set; }

        //Atributo Costo
        //Guarda el costo de la actividad
        public decimal Costo { get; set; }

        //elacion HAS-A con la clase Responsable
        //Una actividad tiene un responsable, por lo que se implementa la relacion HAS-A
        public Responsable Responsable { get; set; }

        //Metodo abstracto 
        //Cada clase hija tiene que implementar su propia validicación
        public abstract bool ValidarInfrmacion();

    }
}
