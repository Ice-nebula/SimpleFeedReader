using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleFeedReader.App.Utils
{
    public static class   XmlDataManager
    {
        /// <summary>
        /// Serialize object to xml string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>xml string</returns>
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("obj can not be blank");
            } //end if
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, obj);
                return writer.ToString();
            };
        } //end method.Serialize
        /// <summary>
        /// Deserialize xml string back to a normal object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }; //end using
        } //end method.Deserialize
    }
}
