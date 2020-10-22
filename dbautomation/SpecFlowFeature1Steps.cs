using System;
using TechTalk.SpecFlow;
using Npgsql;
using System.IO;
using System.Data;

namespace dbautomation
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the first number")]
        public void GivenTheFirstNumber()
        {
            Console.WriteLine("test");
        }

        [Given(@"the second number")]
        public void GivenTheSecondNumber()
        {
            Console.WriteLine("test");
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("test");
        }

        [Then(@"the result should")]
        public void ThenTheResultShould()
        {
            Console.WriteLine("test");
        }

        [Given(@"Source feed file is copied to Incoming folder Listner")]
        public void GivenSourceFeedFileIsCopiedToIncomingFolderListner()
        {
            //Copy target files
            String Destin = @"C:\Users\dawood.khan\source\repos\dbautomationsol\dbautomation\Reference\Incoming\";
            String Source = @"C:\Users\dawood.khan\source\repos\dbautomationsol\dbautomation\Reference\Testdata\";
            File.Copy(Source + "test.csv", Destin + "test.csv");
            Console.WriteLine("File copied to destination folder");


            //Copy All files from the folder 
//########################################## /*
         /* string[] files = Directory.GetFiles(Source);
            foreach (String fil in files){
                string filename = Path.GetFileName(fil);
                File.Copy(fil, Destin + filename, true);
            } */
             

     
        }

        [Given(@"Wait till Records gets processed into the DB")]
        public void GivenWaitTillRecordsGetsProcessedIntoTheDB()
        {
           
        }

        [Then(@"result should be currency = AUD")]
        public void ThenResultShouldBeCurrencyAUD()
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
                        Console.Write("{0}\t{1} \n", dr[0]);


               
                    con.Close();
                }
            }
        }
       
        public void reader()
        {
            using (NpgsqlConnection con = GetConncection())

            {
                con.Open();
                string dataItems;
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Yeah Connected");
                    NpgsqlCommand command = new NpgsqlCommand("SELECT name,age,address FROM public.company", con);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    for (int i=0; dr.Read(); i++)
                    {
                        dataItems = dr[0].ToString();
                        Console.WriteLine(dataItems);
                   
                    }


                    while (dr.Read())
                        Console.Write("{0}\t{1} \n", dr[0]);
                
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
