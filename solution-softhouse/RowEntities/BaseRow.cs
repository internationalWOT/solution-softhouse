using solution_softhouse.Enums;
using solution_softhouse.Interfaces.RowEntities;

namespace solution_softhouse.RowEntities
{
    public class BaseRow : IBaseRow
    {
        public XmlElementType xmlElementType { get; set; } = XmlElementType.xmlRootElement;
    }
}
