using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bogus;

namespace BogusSQL
{
    public class SqlGenerator
    {
        public string TableName { get; set; }
        public int RowCount { get; set; }

        private readonly List<Schema> ListOfColumns;
        
        public SqlGenerator()
        {
            ListOfColumns = new List<Schema>();
        }

        public void SetColumn(string columnName, DataType dataType, DataContent dataContent)
        {
            var schema = new Schema
            {
                ColumnName = columnName,
                ColumnDataType = dataType,
                ColumnDataContent = dataContent
            };
            ListOfColumns.Add(schema);
        }

        public string GenerateSql()
        {
            var sql = GenerateSqlQuery();
            return sql;
        }

        public string GenerateSqlQuery()
        {                      
            var sql = "";
            for (var i = 0; i < RowCount; i++)
            {
                var faker = new Faker();
                var sql1 = "INSERT INTO " + TableName + " (";
                foreach (var column in ListOfColumns)
                {
                    sql1 += column.ColumnName + ",";
                }
                sql1 = sql1.Remove(sql1.LastIndexOf(",", StringComparison.Ordinal));
                sql1 += ") VALUES (";
                var sql2 = "";
                for (var j = 0; j < ListOfColumns.Count; j++)
                {
                    var schema = ListOfColumns.ElementAt(j);
                    switch (schema.ColumnDataContent)
                    {
                        case DataContent.FIRSTNAME:
                            sql2 += "'" + faker.Person.FirstName + "',";
                            break;
                        case DataContent.LASTNAME:
                            sql2 += "'" + faker.Person.LastName + "',";
                            break;
                        case DataContent.GUID:
                            sql2 += "'" + Guid.NewGuid() + "',";
                            break;
                        case DataContent.DATE:
                            sql2 += "'" + faker.Person.DateOfBirth.ToShortDateString() + "',";
                            break;
                        case DataContent.DATETIME:                            
                            sql2 += "'" + faker.Person.DateOfBirth + "',";
                            break;
                        case DataContent.COMPANY:
                            sql2 += "'" + faker.Company.CompanyName() + "',";
                            break;
                        case DataContent.USERNAME:
                            sql2 += "'" + faker.Person.UserName + "',";
                            break;
                        case DataContent.PHONE:
                            sql2 += "'" + faker.Phone.PhoneNumber() + "',";
                            break;
                    }
                }
                sql2 = sql2.Remove(sql2.LastIndexOf(",", StringComparison.Ordinal));
                sql2 += ")";
                sql += sql1 + sql2 + "\n";
            }
            return sql;
        }
    }
}
