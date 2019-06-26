using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.SP
{
    public class Manejadora<T>
    {
        public void Manejador(Cajon<T> cajon)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\incidentes.log");
                sw.WriteLine("Fecha: " + DateTime.Now.ToString());
                sw.WriteLine("Precio del cajon: " + cajon.PrecioTotal.ToString());
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
