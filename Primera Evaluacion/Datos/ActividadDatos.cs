using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primera_Evaluacion.Modelo;
namespace Primera_Evaluacion.Datos
{
    //Capa DATOS
    // Lo que hace es almacenar temp las actividades
    public class ActividadDatos
    {
       //lA LISTA GENERICA
       //Aqui se almacenan las actividades temporalmente
        public List<Actividad> listaActividades { get; set; } = new List<Actividad>();

        //El metodo para agregar una actividad
        public void Agregar(Actividad actividad)
        {
            //Agrega el objeto que reciben a la lista
            listaActividades.Add(actividad);
        }

        //Metodo para consultar las actividades
        public List<Actividad> ObtenerTodas()
        {
            //Regresa la lista de actividades
            return listaActividades;
        }

    }
}
