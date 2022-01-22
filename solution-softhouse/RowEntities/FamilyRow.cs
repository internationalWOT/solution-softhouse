using solution_softhouse.Enums;

namespace solution_softhouse.RowEntities
{
    public class FamilyRow: BaseRow
    {
        public string name { get; set; }
        public string born { get; set; }
        public FamilyRow(XmlElementType xmlElementType, string row)
        {
            string[] split = row.Split("|");
            this.xmlElementType = xmlElementType;
            this.name = split.Length > 1 ? split[1] : string.Empty;
            this.born = split.Length > 2 ? split[2] : string.Empty;
        }

        public FamilyRow(XmlElementType xmlElementType, string row, string delimiter)
        {
            // alternative crt for splitting at custom delimiter
            string[] split = row.Split(delimiter);
            this.xmlElementType = xmlElementType;
            this.name = split.Length > 1 ? split[1] : string.Empty;
            this.born = split.Length > 2 ? split[2] : string.Empty;
        }

    }
}
