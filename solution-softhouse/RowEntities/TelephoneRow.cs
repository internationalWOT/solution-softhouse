using solution_softhouse.Enums;

namespace solution_softhouse.RowEntities
{
    public class TelephoneRow : BaseRow
    {
        public string mobile { get; set; }
        public string landline { get; set; }
        public TelephoneRow(XmlElementType xmlElementType, string row)
        {
            string[] split = row.Split("|");
            this.xmlElementType = xmlElementType;
            this.mobile = split.Length > 1 ? split[1] : string.Empty;
            this.landline = split.Length > 1 ? split[1] : string.Empty;
        }

        public TelephoneRow(XmlElementType xmlElementType, string row, string delimiter)
        {
            // alternative crt for splitting at custom delimiter
            string[] split = row.Split(delimiter);
            this.xmlElementType = xmlElementType;
            this.mobile = split.Length > 1 ? split[1] : string.Empty;
            this.landline = split.Length > 1 ? split[1] : string.Empty;
        }


    }
}
