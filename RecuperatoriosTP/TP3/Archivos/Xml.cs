using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, null);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
