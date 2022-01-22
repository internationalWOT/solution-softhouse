using solution_softhouse.Enums;

namespace solution_softhouse.RowEntities
{
    public class AdressRow : BaseRow
    {
        public string street { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public AdressRow(XmlElementType xmlElementType, string row)
        {
            string[] split = row.Split("|");
            this.xmlElementType = xmlElementType;
            this.street = split.Length > 1 ? split[1] : string.Empty;
            this.city = split.Length > 2 ? split[2] : string.Empty;
            this.zipcode = split.Length > 3 ? split[3] : string.Empty;
        }

        public AdressRow(XmlElementType xmlElementType, string row, string delimiter)
        {
            // alternative crt for splitting at custom delimiter
            string[] split = row.Split(delimiter);
            this.xmlElementType = xmlElementType;
            this.street = split.Length > 1 ? split[1] : string.Empty;
            this.city = split.Length > 2 ? split[2] : string.Empty;
            this.zipcode = split.Length > 3 ? split[3] : string.Empty;
        }
    }

}
