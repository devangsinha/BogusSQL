using System;
using System.Collections.Generic;
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
                RowCount = 100
            };
            obj.SetColumn("GUID", DataType.UNIQUEIDENTIFIER, DataContent.GUID);
            obj.SetColumn("FirstName", DataType.VARCHAR, DataContent.FIRSTNAME);
            obj.SetColumn("LastName", DataType.VARCHAR, DataContent.LASTNAME);
            obj.SetColumn("Birthday", DataType.DATE, DataContent.DATE);
            obj.SetColumn("Timestamp", DataType.DATETIME, DataContent.DATETIME);
            obj.SetColumn("Company", DataType.VARCHAR, DataContent.COMPANY);
            obj.SetColumn("Username", DataType.VARCHAR, DataContent.USERNAME);
            obj.SetColumn("Phone", DataType.VARCHAR, DataContent.PHONE);
            var sql = obj.GenerateSql();
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}
