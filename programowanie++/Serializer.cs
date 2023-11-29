﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace programowanie__
{
    public static class Serializer
    {
        public static T DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)ser.Deserialize(sr);
            }
        }
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());
            using (StreamWriter writer = File.CreateText(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }
    }
}
