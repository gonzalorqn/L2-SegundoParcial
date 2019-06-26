using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Cajon<T> : ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        public event EventoPrecio evento; 

        public List<T> Elementos
        {
            get { return this._elementos; }
        }

        public double PrecioTotal
        {
            get { return this._precioUnitario * this._elementos.Count; }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precio,int capacidad) : this(capacidad)
        {
            this._precioUnitario = precio;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Capacidad: " + this._capacidad.ToString() + " - Cantidad de elementos: " + this._elementos.Count.ToString() + " - Precio total: " + this.PrecioTotal.ToString();
            retorno += "\nElementos:\n";
            foreach (T item in this._elementos)
            {
                retorno += item.ToString() + "\n";
            }
            return retorno;
        }

        public bool Xml(string path)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Cajon<T>));
                StreamWriter sw = new StreamWriter(path);
                serializador.Serialize(sw, this);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Cajon<T> operator +(Cajon<T> cajon,T item)
        {
            if(cajon._elementos.Count < cajon._capacidad)
            {
                cajon._elementos.Add(item);
                if (cajon.PrecioTotal > 55)
                {
                    cajon.evento(cajon);
                }
            }
            else
            {
                throw new CajonLlenoException();
            }
            return cajon;
        }

        public delegate void EventoPrecio(Cajon<T> cajon);
    }
}
