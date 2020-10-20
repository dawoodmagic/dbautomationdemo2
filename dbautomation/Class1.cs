/*

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dbautomation
{
    class Class1
    {
        

        static void main(string[] args)
        {
            TestConnection();
            Console.ReadKey();
        }


        [TestMethod]
        private static void TestConnection()
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
        private static NpgsqlConnection GetConncection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port =5432;User Id=postgres;Password=datahub;Database = postgres");
        }

    }
}

*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Npgsql;

using System.Data;
using System.Text;

//C:\Users\dawood.khan\source\repos\dbautomationsol\dbautomation\UnitTest1.cs

//C: \Users\dawood.khan\source\repos\dbautomationsol\dbautomation\Class1.cs

namespace dbautomation
{

    public class Class1
    {
        

        [TestMethod]
        public void TestMethod7()
        {
            Console.WriteLine("This is my first test");
        }


    }
}
