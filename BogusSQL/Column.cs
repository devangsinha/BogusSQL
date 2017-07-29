using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusSQL
{
    public class Column
    {
        public DataType ColumnDataType { get; set; }
        public DataContent ColumnDataContent { get; set; }
        public string ColumnName { get; set; }
        public int ValueFrequency { get; set; } = 0;
        public object DefaultValue { get; set; }
        public string Format { get; set; }
    }
}
