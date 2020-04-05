using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class XmlWriter : IXmlWriter
    {
        public void Serialize(CycleInfo cycleInfo)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            XmlSerializer serializer =
            new XmlSerializer(typeof(CycleInfo));
            TextWriter writer = new StreamWriter(cycleInfo.CycleId.ToString());

            // Serializes the purchase order, and closes the TextWriter.
            serializer.Serialize(writer, cycleInfo);
            writer.Close();
        }

    }
}
