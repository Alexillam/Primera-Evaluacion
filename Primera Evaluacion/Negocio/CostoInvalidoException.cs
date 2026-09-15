using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_Evaluacion.Negocio
{
    //Exepción personalizada para manejar el caso de un costo inválido
    public class CostoInvalidoException : Exception
    {
        //Constructor de la excepción 
        public CostoInvalidoException(string message) : base(message)
        {
        }
    }
}
