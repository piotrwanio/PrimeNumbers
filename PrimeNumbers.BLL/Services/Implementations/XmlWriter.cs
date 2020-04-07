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
        //TODO: Need to fix timestamp serialization
        //TODO: using? dispose?
        public void Serialize(IList<BasicCycleInfo> cycleInfo)
        {
            XmlSerializer serializer =
            new XmlSerializer(typeof(List<BasicCycleInfo>));
            TextWriter writer = new StreamWriter("cycles_report.xml");

            serializer.Serialize(writer, cycleInfo.ToList());
            writer.Close();
        }

    }
}
