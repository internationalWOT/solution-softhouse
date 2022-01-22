using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using solution_softhouse.Enums;

namespace solution_softhouse.Interfaces.RowEntities
{
    interface IBaseRow
    {
        public XmlElementType xmlElementType { get; set; }
    }
}
