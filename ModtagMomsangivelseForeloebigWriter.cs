using System;
using System.Xml;

namespace UFSTWSSecuritySample
{
    public class ModtagMomsangivelseForeloebigWriter : IPayloadWriter
    {
        public ModtagMomsangivelseForeloebigWriter(string SENummer, string AngivelsePeriodeFraDato, string AngivelsePeriodeTilDato, Dictionary<string, string> AngivelsesAfgifter)
        {
            seNummer = SENummer;
            this.AngivelsePeriodeFraDato = AngivelsePeriodeFraDato;
            this.AngivelsePeriodeTilDato = AngivelsePeriodeTilDato;
            this.AngivelsesAfgifter = AngivelsesAfgifter;
        }

        public void Write(XmlTextWriter writer)
        {
            var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
            var transactionId = Guid.NewGuid().ToString();

            writer.WriteStartElement("urn", "ModtagMomsangivelseForeloebig_I", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("ns", "HovedOplysninger", "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
            writer.WriteStartElement("ns", "TransaktionIdentifikator", null);
            writer.WriteString(transactionId);
            writer.WriteEndElement(); // TransaktionIdentifikator
            writer.WriteStartElement("ns", "TransaktionTid", null);
            writer.WriteString(now);
            writer.WriteEndElement(); // TransaktionTid
            writer.WriteEndElement(); // HovedOplysninger
            writer.WriteStartElement("urn", "Angivelse", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("urn", "AngiverVirksomhedSENummer", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("ns1", "VirksomhedSENummerIdentifikator", "http://rep.oio.dk/skat.dk/motor/class/virksomhed/xml/schemas/20080401/");
            writer.WriteString(seNummer);
            writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
            writer.WriteEndElement(); // AngiverVirksomhedSENummer
            writer.WriteStartElement("urn", "Angivelsesoplysninger", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteStartElement("urn1", "AngivelsePeriodeFraDato", "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteString(AngivelsePeriodeFraDato);
            writer.WriteEndElement(); // SoegeDatoFraDate
            writer.WriteStartElement("urn1", "AngivelsePeriodeTilDato", "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteString(AngivelsePeriodeTilDato);
            writer.WriteEndElement(); // Angivelsesoplysninger
            writer.WriteStartElement("urn", "Angivelsesafgifter", null);
            foreach (KeyValuePair<string, string> kvp in AngivelsesAfgifter){
                writer.WriteStartElement("urn1", kvp.Key, "urn:oio:skat:nemvirksomhed:1.0.0");
                writer.WriteString(kvp.Value);
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // Angivelsesafgifter
            writer.WriteEndElement(); // Angivelse
            writer.WriteEndElement(); // ModtagMomsangivelseForeloebig_I
        }

        private string seNummer;

        private string AngivelsePeriodeFraDato;

        private string AngivelsePeriodeTilDato;

        private Dictionary<string, string> AngivelsesAfgifter;

    }
}
