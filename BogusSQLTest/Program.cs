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
                RowCount = 10000
            };
            obj.SetColumn("GUID", DataType.UNIQUEIDENTIFIER, DataContent.GUID);
            obj.SetColumn("FirstName", DataType.VARCHAR, DataContent.FIRSTNAME);
            obj.SetColumn("LastName", DataType.VARCHAR, DataContent.LASTNAME);
            var sql = obj.GenerateSql();
            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}
