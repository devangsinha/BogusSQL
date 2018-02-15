using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bogus;

namespace BogusSQL
{
    public class SqlGenerator
    {
        public string TableName { get; set; }
        public int RowCount { get; set; }

        private List<Column> ListOfColumns;
        
        public SqlGenerator()
        {
            ListOfColumns = new List<Column>();
        }

        public void SetColumns(List<Column> columns)
        {
            ListOfColumns = columns;
        }

        private static void BuildSqlQuery(StringBuilder sql, object randomValue, Column column)
        {
            if (column.AllowNull)
            {
                var random = new Random();
                if (random.Next() % 3 == 0)
                {
                    randomValue = "NULL";
                }
            }

            if (column.SetNull)
            {
                randomValue = "NULL";
            }
            sql.Append("'" + (column.DefaultValue ?? randomValue) + "',");
        }

        private static void AddColumnValueToSql(Column column, StringBuilder sql, Faker faker)
        {
            switch (column.ColumnDataContent)
            {
                case DataContent.FULLNAME:
                    BuildSqlQuery(sql, faker.Person.FirstName.Replace("'", "") + " " + faker.Person.LastName.Replace("'", ""), column);
                    break;
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
                case DataContent.LATITUDE:
                    BuildSqlQuery(sql, faker.Address.Latitude().ToString(), column);
                    break;
                case DataContent.LONGITUDE:
                    BuildSqlQuery(sql, faker.Address.Longitude().ToString(), column);
                    break;
                case DataContent.STREETADDRESS:
                    BuildSqlQuery(sql, faker.Address.StreetAddress().Replace("'", ""), column);
                    break;
                case DataContent.CITY:
                    BuildSqlQuery(sql, faker.Address.City().Replace("'", ""), column);
                    break;
                case DataContent.STATE:
                    BuildSqlQuery(sql,
                        column.UseAbbreviation ? faker.Address.StateAbbr() : faker.Address.State(), column);
                    break;
                case DataContent.ZIP:
                    BuildSqlQuery(sql, faker.Address.ZipCode(column.Format), column);
                    break;
                case DataContent.COUNTRY:
                    BuildSqlQuery(sql, faker.Address.Country().Replace("'", ""), column);
                    break;
                case DataContent.ALPHANUMERIC:
                    AddAlphanumericColumnValueToSql(column, sql);
                    break;
                case DataContent.WEBSITE:
                    BuildSqlQuery(sql, faker.Internet.Url(), column);
                    break;
            }
        }

        private static void AddAlphanumericColumnValueToSql(Column column, StringBuilder sql)
        {
            if (column.UseLettersOnly == false && column.UseNumbersOnly == false &&
                column.UseLettersAndNumbers == false && column.Length == 8)
            {
                BuildSqlQuery(sql, new Randomizer().Replace("********"), column);
            }
            else if (column.UseLettersOnly && column.UseNumbersOnly == false &&
                     column.UseLettersAndNumbers == false && column.Length == 8)
            {
                BuildSqlQuery(sql, new Randomizer().Replace("????????"), column);
            }
            else if (column.UseLettersOnly == false && column.UseNumbersOnly &&
                     column.UseLettersAndNumbers == false && column.Length == 8)
            {
                BuildSqlQuery(sql, new Randomizer().Replace("########"), column);
            }
            else if (column.UseLettersOnly && column.UseNumbersOnly == false &&
                     column.UseLettersAndNumbers == false && column.Length != 8)
            {
                BuildSqlQuery(sql, new Randomizer().Replace(new string('?', column.Length)), column);
            }
            else if (column.UseLettersOnly == false && column.UseNumbersOnly &&
                     column.UseLettersAndNumbers == false && column.Length != 8)
            {
                BuildSqlQuery(sql, new Randomizer().Replace(new string('#', column.Length)), column);
            }
            else
            {
                BuildSqlQuery(sql, new Randomizer().Replace(new string('*', column.Length)), column);
            }
        }

        private static void WriteSqlToFile(string sql)
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
                    AddColumnValueToSql(column, sql, faker);
                }
                sql.Length -= 1;
                sql.Append(")\n");
            }
            WriteSqlToFile(sql.ToString());
        }
    }
}
