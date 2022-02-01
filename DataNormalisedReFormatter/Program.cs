using System;

namespace DataNormalisedReFormatter
{
    public class Program
    {
        public static string InputFile;
        public static string OutputFile;

        private static void Main(string[] args)
        {
            //Set statics manually
            InputFile = @"D:\DummyData\Email.csv";
            OutputFile = @"D:\DummyData\testResult.csv";

            try
            {
                DataReader reader = new DataReader();
                reader.ReadData(InputFile);
                reader.ProcessData();
                reader.WriteData(OutputFile);

                //ProcessInputFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}