using solution_softhouse.Enums;
using solution_softhouse.Interfaces.RowEntities;

namespace solution_softhouse.RowEntities
{

    public class BaseRow : IBaseRow
    {
        /*
         * Organizing the rowtypes by elementtype. not used in this implementation
         * but can be used in future ones where you want more complex behaviour based on
         * what type you are using.
         */
        public XmlElementType xmlElementType { get; set; } = XmlElementType.xmlRootElement;
    }
}
