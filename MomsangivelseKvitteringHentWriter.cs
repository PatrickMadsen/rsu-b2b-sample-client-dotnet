using System;
using System.Xml;

namespace UFSTWSSecuritySample
{
    public class MomsangivelseKvitteringHentWriter : IPayloadWriter
    {
        public MomsangivelseKvitteringHentWriter(string SENummer, string TransaktionIdentifier)
        {
            seNummer = SENummer;
            this.transaktionIdentifier = TransaktionIdentifier;
        }

        public void Write(XmlTextWriter writer)
        {
            var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
            var transactionId = Guid.NewGuid().ToString();

            writer.WriteStartElement("urn", "MomsangivelseKvitteringHent_I", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("ho", "HovedOplysninger", "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
            writer.WriteStartElement("ho", "TransaktionIdentifikator", null);
            writer.WriteString(transactionId);
            writer.WriteEndElement(); // TransaktionIdentifikator
            writer.WriteStartElement("ho", "TransaktionTid", null);
            writer.WriteString(now);
            writer.WriteEndElement(); // TransaktionTid
            writer.WriteEndElement(); // HovedOplysninger
            writer.WriteStartElement("urn1", transaktionIdentifier, null);
            writer.WriteString(transaktionIdentifier);
            writer.WriteEndElement(); // transaktionIdentifier
            writer.WriteStartElement("urn", "Angiver", null);
            writer.WriteStartElement("ns1", "VirksomhedSENummerIdentifikator", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteString(seNummer);
            writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
            writer.WriteEndElement(); // Angiver
            writer.WriteEndElement(); // MomsangivelseKvitteringHent_I
        }

        private string seNummer;

        private string transaktionIdentifier;

    }
}
