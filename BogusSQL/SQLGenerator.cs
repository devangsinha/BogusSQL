﻿using System;
using System.Collections.Generic;
using System.IO;
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

        private static void BuildSqlQuery(StringBuilder sql, object randomValue, Column column)
        {
            if (column.ValueFrequency == 0)
            {
                sql.Append("'" + (column.DefaultValue ?? randomValue) + "',");
            }
            else
            {
                column.DefaultValue = (column.DefaultValue ?? randomValue);
                sql.Append("'" + column.DefaultValue + "',");
                column.ValueFrequency--;
                if (column.ValueFrequency == 0)
                {
                    column.DefaultValue = null;
                }
            }
        }

        private static void WriteSQLToFile(string sql)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fileName = "SQLQuery_" + DateTime.Now.ToShortDateString().Replace("/", "");
            var extension = ".sql";
            var fullPath = path + "\\" + fileName + extension;
            var count = 1;

            while (File.Exists(fullPath))
            {
                var tempFileName = string.Format("{0}({1})", fileName, count++);
                fullPath = Path.Combine(path, tempFileName + extension);                
            }
            File.WriteAllText(fullPath, sql);
        }

        public void GenerateSqlQuery()
        {                      
            var sql = new StringBuilder();
            for (var i = 0; i < RowCount; i++)
            {
                var faker = new Faker();
                sql.Append("INSERT INTO " + TableName + " (");
                foreach (var column in ListOfColumns)
                {
                    sql.Append(column.ColumnName + ",");
                }
                sql.Length -= 1;
                sql.Append(") VALUES (");
                for (var j = 0; j < ListOfColumns.Count; j++)
                {
                    var column = ListOfColumns.ElementAt(j);
                    switch (column.ColumnDataContent)
                    {
                        case DataContent.FIRSTNAME:
                            BuildSqlQuery(sql, faker.Person.FirstName.Replace("'", ""), column);
                            break;
                        case DataContent.LASTNAME:                           
                            BuildSqlQuery(sql, faker.Person.LastName.Replace("'", ""), column);                           
                            break;
                        case DataContent.GUID:
                            sql.Append("'" + Guid.NewGuid() + "',");
                            break;
                        case DataContent.DATE:
                            BuildSqlQuery(sql, faker.Person.DateOfBirth.ToShortDateString(), column);                           
                            break;
                        case DataContent.DATETIME:                            
                            BuildSqlQuery(sql, faker.Person.DateOfBirth, column);                           
                            break;
                        case DataContent.COMPANY:
                            BuildSqlQuery(sql, faker.Company.CompanyName().Replace("'", ""), column);                           
                            break;
                        case DataContent.USERNAME:                            
                            BuildSqlQuery(sql, faker.Person.UserName.Replace("'", ""), column);                           
                            break;
                        case DataContent.PHONE:             
                             BuildSqlQuery(sql, faker.Phone.PhoneNumber(column.Format), column);                           
                            break;
                    }
                }
                sql.Length -= 1;
                sql.Append(")\n");
            }
            WriteSQLToFile(sql.ToString());
        }
    }
}
