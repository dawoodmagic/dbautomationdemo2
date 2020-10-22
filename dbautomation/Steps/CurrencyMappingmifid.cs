using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Npgsql;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dbautomation.Steps
{
    [Binding]
    public sealed class CurrencyMappingmifid
    {
        [Given(@"Currency value is AU")]
        public void GivenCurrencyValueIsAU(Table table)
        {
            CurrencyMapping details= table.CreateInstance<CurrencyMapping>();
            Console.WriteLine(details.Currency);
       }

        [When(@"Transaciton gets processed")]
        public void WhenTransacitonGetsProcessed()
        {
            using (NpgsqlConnection con = GetConncection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Fetch field transaction value");
                    NpgsqlCommand command = new NpgsqlCommand("Select currency from public.transaction where currency = 'USA'", con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                   
                    Console.Write("{0}\n", dr[0] );
                 
               

                    con.Close();
                }
            }
        }







   


        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string p0, Table table)
        {


            CurrencyMapping details = table.CreateInstance<CurrencyMapping>();
            string cn = details.Currency;

           // Console.WriteLine(details.Currency);
            using (NpgsqlConnection con = GetConncection())
            {
                con.Open();
                string dataItems;
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Yeah Connected");
                    NpgsqlCommand command = new NpgsqlCommand("Select currency from public.transaction where currency = 'USA'", con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    for (int i = 0; dr.Read(); i++)
                    {
                        dataItems = dr[0].ToString();
                        Console.WriteLine(dataItems);
                        Console.WriteLine("Matching Actual vs Expected");
                        Console.WriteLine(dataItems.Equals(cn));

                        if (dataItems != cn) throw new ArgumentNullException("scenario failed as Actual vs Expected didn't match");

                        //try
                        //{

                        //    if (dataItems == cn)
                        //    {
                        //        Console.WriteLine("Expected result Match");
                               
                        //    }
                        //    else
                        //    { }
                        //         if (dataItems != p0) throw new ArgumentNullException("scenario failed");


                        //    }

                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine("Message : " + ex.Message);
                        //    Console.WriteLine("Stack Trace : " + ex.StackTrace);
                        //}


                    }


                   // while (dr.Read())
                     //   Console.Write("{0}\t{1} \n", dr[0]);

                    con.Close();
                }

            }
        }

        

     

        private static NpgsqlConnection GetConncection()
    {
        return new NpgsqlConnection(@"Server=localhost;Port =5432;User Id=postgres;Password=datahub;Database = postgres");
    }
}
}
