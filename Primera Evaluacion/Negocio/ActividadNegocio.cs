using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primera_Evaluacion.Datos;
using Primera_Evaluacion.Modelo;

namespace Primera_Evaluacion.Negocio
{
    //Esta es la capa negocio 
    //Contiene las reglas de negocio y las validaciones
    public class ActividadNegocio
    {
        //Objeto de la capa datos
        //Aqui permite guardar y consultar las actividades
        private ActividadDatos datos = new ActividadDatos();

        //Varibale para generar el id automaticamente
        private static int siguienteId = 1;

        //El metodo para registrar una actividad
        public void Registrar (Actividad actividad)
        {
            //La regla de negocio
            // Es que el costo tiene que ser mayor a cero
            if(actividad.Costo <= 0)
            {
                throw new CostoInvalidoException("El costo debe ser mayor a cero");
            }

            //Validamos la informacion de cada tipo de actividad
            if (!actividad.ValidarInfrmacion())
            {
                throw new System.ArgumentException("La información de la actividad es inválida");
            }

            //Asignamos un id unico a la actividad
            actividad.Id = siguienteId;

            //Incrementamos el contador para que se pueda el siguiente registro
            siguienteId++;

            //Eviamos el objeto a la capa datos
            //para que se almacene a la lista
            datos.Agregar(actividad);
        }

        //Metodo para consultar todas las actividades
        public List<Actividad> ObtenerActividades()
        {
            //Regresamos la lista de actividades
            return datos.ObtenerTodas();
        }
    }
}
