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
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.FIRSTNAME,
                ColumnName = "FirstName",
                DefaultValue = "DEVANG",
                ValueFrequency = 3
            };
            var column3 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
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
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.COMPANY,
                ColumnName = "Company"
            };
            var column7 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.USERNAME,
                ColumnName = "Username"
            };
            var column8 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.PHONE,
                ColumnName = "Phone",
                Format = "###-###-####"
            };
            var column9 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.LATITUDE,
                ColumnName = "Latitude"
            };
            var column10 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.LONGITUDE,
                ColumnName = "Longitude"
            };
            var column11 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.STREETADDRESS,
                ColumnName = "Street Address"
            };
            var column12 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.CITY,
                ColumnName = "City"
            };
            var column13 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.STATE,
                ColumnName = "State",
                UseAbbreviation = true
            };
            var column14 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.ZIP,
                ColumnName = "Zip",
                Format = "###"
            };
            var column15 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.COUNTRY,
                ColumnName = "Country",
                DefaultValue = "US"
            };
            var column16 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.ALPHANUMERIC,
                ColumnName = "SerialNumber",
                Length = 5,
                UseLettersAndNumbers = true
            };
            var column17 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.FULLNAME,
                ColumnName = "Manager"
            };

            obj.SetColumn(column1);
            obj.SetColumn(column2);
            obj.SetColumn(column3);
            obj.SetColumn(column4);
            obj.SetColumn(column5);
            obj.SetColumn(column6);
            obj.SetColumn(column7);
            obj.SetColumn(column8); 
            obj.SetColumn(column9); 
            obj.SetColumn(column10); 
            obj.SetColumn(column11); 
            obj.SetColumn(column12); 
            obj.SetColumn(column13); 
            obj.SetColumn(column14);
            obj.SetColumn(column15);
            obj.SetColumn(column16);
            obj.SetColumn(column17);

            obj.GenerateSqlQuery();
        }
    }
}
