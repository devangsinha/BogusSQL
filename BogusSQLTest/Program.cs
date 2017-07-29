using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  BogusSQL;

namespace BogusSQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new SqlGenerator
            {
                TableName = "MyTable",
                RowCount = 70
            };
            var column1 = new Column
            {
                ColumnDataType = DataType.UNIQUEIDENTIFIER,
                ColumnDataContent = DataContent.GUID,
                ColumnName = "Id"
            };
            var column2 = new Column
            {
                ColumnDataType = DataType.VARCHAR,
                ColumnDataContent = DataContent.FIRSTNAME,
                ColumnName = "FirstName",
                DefaultValue = "DEVANG",
                ValueFrequency = 3
            };
            var column3 = new Column
            {
                ColumnDataType = DataType.VARCHAR,
                ColumnDataContent = DataContent.LASTNAME,
                ColumnName = "LastName",
                ValueFrequency = 2
            };
            var column4 = new Column
            {
                ColumnDataType = DataType.DATE,
                ColumnDataContent = DataContent.DATE,
                ColumnName = "Birthday",
                ValueFrequency = 4
            };
            var column5 = new Column
            {
                ColumnDataType = DataType.DATETIME,
                ColumnDataContent = DataContent.DATETIME,
                ColumnName = "Timestamp"
            };
            var column6 = new Column
            {
                ColumnDataType = DataType.VARCHAR,
                ColumnDataContent = DataContent.COMPANY,
                ColumnName = "Company"
            };
            var column7 = new Column
            {
                ColumnDataType = DataType.VARCHAR,
                ColumnDataContent = DataContent.USERNAME,
                ColumnName = "Username"
            };
            var column8 = new Column
            {
                ColumnDataType = DataType.VARCHAR,
                ColumnDataContent = DataContent.PHONE,
                ColumnName = "Phone",
                Format = "###-###-####"
            };
            obj.SetColumn(column1);
            obj.SetColumn(column2);
            obj.SetColumn(column3);
            obj.SetColumn(column4);
            obj.SetColumn(column5);
            obj.SetColumn(column6);
            obj.SetColumn(column7);
            obj.SetColumn(column8); 
            
            obj.GenerateSqlQuery();
            //Console.ReadKey();
        }
    }
}
