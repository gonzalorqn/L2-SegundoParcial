using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string Nombre
        {
            get { return "Manzana"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public Manzana():this("verde", 2, "rio negro")
        {

        }

        public Manzana(string color,double peso,string provinciaOrigen) : base(color,peso)
        {
            this._provinciaOrigen = provinciaOrigen;
        }

        public override string ToString()
        {
            return base.FrutaToString() + " - Provincia de origen: " + this._provinciaOrigen;
        }

        public bool Xml(string path)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));
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

        bool IDeserializar.Xml(string path, out Fruta item)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));
                StreamReader sr = new StreamReader(path);
                item = (Manzana)serializador.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                item = null;
                return false;
            }
        }
    }
}
