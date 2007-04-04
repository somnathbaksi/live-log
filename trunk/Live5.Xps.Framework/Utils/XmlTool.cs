using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace Live5.Xps.Framework.Utils
{
    public class XmlTool
    {
        public static TObject XmlToObject<TObject>(XmlDocument xmlDoc)
        {
            
            TObject obj = Activator.CreateInstance<TObject>();
            MemoryStream stream = new MemoryStream();
            xmlDoc.Save(stream);
            stream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            obj = (TObject)serializer.Deserialize(stream);
            return obj;
        }
        public static XmlDocument ObjectToXml(object obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stream, obj);
            stream.Position = 0;
            xmlDoc.Load(stream);
            return xmlDoc;
        }
        public static object XmlToObject(Type type, XmlDocument xmlDoc)
        {
            object obj=null;
            MemoryStream stream = new MemoryStream();
            xmlDoc.Save(stream);
            stream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(type);
            obj = serializer.Deserialize(stream);
            return obj;
        }
    }
}
