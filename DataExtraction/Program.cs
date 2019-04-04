using System;


/*References: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
 *           
 *            https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
 * 
 * This program reads records from a csv file ("simpligov_data_dump_12_18_2018.csv") and write records into two differet files.
 * 
 */



namespace DataExtraction
{
    public class Program
    {
        static string originalFile = @"C:\Users\skang\Documents\TradeMarks\18000.csv";
        static string llcPath = @"C:\Users\skang\Documents\TradeMarks\dump_file.csv";
        static string tmPath = @"C:\Users\skang\Documents\TradeMarks\dump_fileTM.csv";
        static string tm100Path = @"C:\Users\skang\Documents\TradeMarks\dump_fileTMTM10.csv";

        public static void Main(string[] args)
        {
            WriteData();
            //ReadData();
        }

        public static void WriteData()
        {
            int count = 0;

            string[] lines = System.IO.File.ReadAllLines(originalFile);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(tmPath))
            {
                foreach (string line in lines)
                {
                    //Change a value to 'False' if a record should not contain 'LLC1' 
                    if (line.Contains("LLC1") == false)
                    {
                        file.WriteLine(line);
                        count++;

                        Console.WriteLine(line);

                    }

                }

            }
            Console.WriteLine(count);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }
        static void ReadData()
        {
            int count = 0;

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\skang\Documents\data_dump_12_18_2018.csv");

            foreach (string line in lines)
            {

                if (line.Contains("LLC1") == true)
                {
                    Console.WriteLine("Word found!: " + line);
                    count++;
                }

            }
            Console.WriteLine(count);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }

    }
}
