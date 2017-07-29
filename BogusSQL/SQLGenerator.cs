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

        public string GenerateSql()
        {
            var sql = GenerateSqlQuery();
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
                    var valueFrequency = column.ValueFrequency;
                    switch (column.ColumnDataContent)
                    {
                        case DataContent.FIRSTNAME:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Person.FirstName) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Person.FirstName);
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.LASTNAME:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Person.LastName) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Person.LastName);
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.GUID:
                            sql2 += "'" + Guid.NewGuid() + "',";
                            break;
                        case DataContent.DATE:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Person.DateOfBirth.ToShortDateString()) +
                                        "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Person.DateOfBirth.ToShortDateString());
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.DATETIME:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Person.DateOfBirth) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Person.DateOfBirth);
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.COMPANY:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Company.CompanyName()) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Company.CompanyName());
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.USERNAME:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Person.UserName) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Person.UserName);
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
                            break;
                        case DataContent.PHONE:
                            if (valueFrequency == 0)
                            {
                                sql2 += "'" + (column.DefaultValue ?? faker.Phone.PhoneNumber()) + "',";
                            }
                            else
                            {
                                column.DefaultValue = (column.DefaultValue ?? faker.Phone.PhoneNumber());
                                sql2 += "'" + column.DefaultValue + "',";
                                column.ValueFrequency--;
                                if (column.ValueFrequency == 0)
                                {
                                    column.DefaultValue = null;
                                }
                            }
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
