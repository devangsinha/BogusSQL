using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusSQL
{
    class Schema
    {
        public string ColumnName { get; set; }
        public DataType ColumnDataType { get; set; }
        public DataContent ColumnDataContent { get; set; }
    }
}
