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
        public object DefaultValue { get; set; }
        public string Format { get; set; }
        public bool UseAbbreviation { get; set; }
        public bool UseNumbersOnly { get; set; }
        public bool UseLettersOnly { get; set; }
        public bool UseLettersAndNumbers { get; set; }
        public int Length { get; set; } = 8;
        public bool AllowNull { get; set; } = false;
        public bool SetNull { get; set; }
    }
}
