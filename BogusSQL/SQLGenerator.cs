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

        private readonly List<Column> ListOfColumns;
        
        public SqlGenerator()
        {
            ListOfColumns = new List<Column>();
        }

        public void SetColumn(Column column)
        {
            ListOfColumns.Add(column);
        }

        private static string BuildSqlQuery(string sql, object randomValue, Column column)
        {
            if (column.ValueFrequency == 0)
            {
                sql += "'" + (column.DefaultValue ?? randomValue) + "',";
            }
            else
            {
                column.DefaultValue = (column.DefaultValue ?? randomValue);
                sql += "'" + column.DefaultValue + "',";
                column.ValueFrequency--;
                if (column.ValueFrequency == 0)
                {
                    column.DefaultValue = null;
                }
            }
            return sql;
        }

        private string GenerateSqlQuery()
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
                    var column = ListOfColumns.ElementAt(j);
                    switch (column.ColumnDataContent)
                    {
                        case DataContent.FIRSTNAME:
                            sql2 = BuildSqlQuery(sql2, faker.Person.FirstName, column);
                            break;
                        case DataContent.LASTNAME:                           
                            sql2 = BuildSqlQuery(sql2, faker.Person.LastName, column);                           
                            break;
                        case DataContent.GUID:
                            sql2 += "'" + Guid.NewGuid() + "',";
                            break;
                        case DataContent.DATE:
                            sql2 = BuildSqlQuery(sql2, faker.Person.DateOfBirth.ToShortDateString(), column);                           
                            break;
                        case DataContent.DATETIME:                            
                            sql2 = BuildSqlQuery(sql2, faker.Person.DateOfBirth, column);                           
                            break;
                        case DataContent.COMPANY:
                            sql2 = BuildSqlQuery(sql2, faker.Company.CompanyName(), column);                           
                            break;
                        case DataContent.USERNAME:                            
                            sql2 = BuildSqlQuery(sql2, faker.Person.UserName, column);                           
                            break;
                        case DataContent.PHONE:             
                             sql2 = BuildSqlQuery(sql2, faker.Phone.PhoneNumber(column.Format), column);                           
                            break;
                    }
                }
                sql2 = sql2.Remove(sql2.LastIndexOf(",", StringComparison.Ordinal));
                sql2 += ")";
                sql += sql1 + sql2 + "\n";
            }
            return sql;
        }

        public string GenerateSql()
        {
            var sql = GenerateSqlQuery();
            return sql;
        }
    }
}
