using solution_softhouse.Enums;

namespace solution_softhouse.RowEntities
{
    class PersonRow : BaseRow
    {
        public string firstname { get; set; }
        public string lastname{ get; set; }

        public PersonRow(XmlElementType xmlElementType, string row)
        {
            this.xmlElementType = xmlElementType;
            string[] split = row.Split("|");
            firstname = split.Length > 1 ? split[1] : string.Empty;
            lastname = split.Length > 2 ? split[2] : string.Empty;
        }

        public PersonRow(XmlElementType xmlElementType, string row, string delimiter)
        {
            // alternative crt for splitting at custom delimiter
            this.xmlElementType = xmlElementType;
            string[] split = row.Split(delimiter);
            firstname = split.Length > 1 ? split[1] : string.Empty;
            lastname = split.Length > 2 ? split[2] : string.Empty;
        }
    }
}
