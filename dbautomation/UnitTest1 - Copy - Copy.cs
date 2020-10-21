using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Npgsql;

using System.Data;
using System.Text;

//C:\Users\dawood.khan\source\repos\dbautomationsol\dbautomation\UnitTest1.cs

//C: \Users\dawood.khan\source\repos\dbautomationsol\dbautomation\Class1.cs
//test
namespace dbautomation
{
    [TestClass]
    public class TCID39VerifyCurrencyFieldTransalation
    {

        [TestMethod]

        public void EstablishingDbConnection()
        {
            using (NpgsqlConnection con = GetConncection())

            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Yeah Connected");
              
                }
            }

        }
        [TestMethod]
        public void rawtablecountcheck()
        {
            using (NpgsqlConnection con = GetConncection())

            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Yeah Connected");
                    NpgsqlCommand command = new NpgsqlCommand("SELECT count(*) FROM public.company", con);
                    Int64 count = (Int64)command.ExecuteScalar();
                    Console.Write("{0}\n", count);
                    con.Close();
                }
            }
  
        }

        [TestMethod]
        public void DbresultSet()
        {
            using (NpgsqlConnection con = GetConncection())

            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Yeah Connected");
                    NpgsqlCommand command = new NpgsqlCommand("SELECT name,age,address FROM public.company", con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                        Console.Write("{0}\t{1} \n", dr[0], dr[1],dr[2]);
                    con.Close();
                }
            }

        }


        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine("This is my first test");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Console.WriteLine("This is my first test");
        }
    private static NpgsqlConnection GetConncection()
    {
        return new NpgsqlConnection(@"Server=localhost;Port =5432;User Id=postgres;Password=datahub;Database = postgres");
    }

      

      

    }
}
