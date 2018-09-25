using Oracle.DataAccess.Client;
using System;
using System.Text;

namespace TestOracleDbConnectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = @"Data Source=(Description=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));DBA Privilege = SYSDBA;User Id = sys;Password=oracle";
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = connStr;
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection opened.");
                    var cmd = new OracleCommand("select * from dual", conn);
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                sb.Append(dr[i].ToString());
                                sb.Append(" ");
                            }
                            Console.WriteLine(sb);
                        }
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine(ex.ToString()); ;
                }
            }
            Console.WriteLine("hello");
            Console.ReadLine();
        }

    }
}
