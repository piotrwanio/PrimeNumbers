using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class XmlWriter : IXmlWriter
    {
        public void Serialize(IList<BasicCycleInfo> cycleInfo)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            XmlSerializer serializer =
            new XmlSerializer(typeof(List<BasicCycleInfo>));
            TextWriter writer = new StreamWriter("cycles_report.xml");

            // Serializes the purchase order, and closes the TextWriter.
            serializer.Serialize(writer, cycleInfo.ToList());
            writer.Close();
        }

    }
}
