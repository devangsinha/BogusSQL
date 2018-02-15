# BogusSQL
A C# class library for easily generating SQL INSERT statements for large amount of random test data

## Features

* Create large volumes of data in C#
* Generate meaningful test data at row level
* Extremely fast data generation

## Install BogusSQL via NuGet

If you want to include BogusSQL in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/BogusSQL)

To install BogusSQL, run the following command in the Package Manager Console

```
PM> Install-Package BogusSQL -Version 1.0.0
```

## How to use:
```
using System.Collections.Generic;
using BogusSQL;

namespace BogusSQLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new SqlGenerator
            {
                TableName = "MyTable",
                RowCount = 7000
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
                DefaultValue = "DEVANG"
            };
            var column3 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.LASTNAME,
                ColumnName = "LastName"
            };
            var column4 = new Column
            {
                ColumnDataType = DataType.DATE,
                ColumnDataContent = DataContent.DATE,
                ColumnName = "Birthday"
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
                ColumnName = "Company",
                AllowNull = true
            };
            var column7 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.USERNAME,
                ColumnName = "Username",
                SetNull = true
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
            var column18 = new Column
            {
                ColumnDataType = DataType.NVARCHAR,
                ColumnDataContent = DataContent.WEBSITE,
                ColumnName = "Personal Website"
            };

            var columns = new List<Column>()
            {
                column1,
                column2,
                column3,
                column4,
                column5,
                column6,
                column7,
                column8,
                column9,
                column10,
                column11,
                column12,
                column13,
                column14,
                column15,
                column16,
                column17,
                column18
            };
            
            obj.SetColumns(columns);

            obj.GenerateSqlQuery();            
        }
    }
}
```

The SQL file containing INSERT statements will be generated on Desktop
