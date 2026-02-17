using System.Data.Common;

namespace FileIOExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\..\\TestFile.txt";
            string Data = "..\\..\\..\\UserData.txt";
            string[,] customerData = ReadFileIntoArray(Data);
            //WriteToFile(filePath);
            //AppendToFile(filePath);
            //ReadFromFile(filePath);
            //ReadWholeFile(Data);
            DisplayCustomerData(customerData);

            Console.Read();
        }

        static void WriteToFile(string path) 
        {
            using (StreamWriter currentFile = File.CreateText(path))
            {
                currentFile.WriteLine("Wake up Neo...");
            }
        }

        static void AppendToFile(string path)
        {
            using (StreamWriter currentFile = File.AppendText(path))
            {
                currentFile.WriteLine("Follow the White Rabbit...");
            }
        }

        static void ReadFromFile(string path)
        {
            using (StreamReader currentFile = new StreamReader(path))
            {
                Console.WriteLine(currentFile.ReadLine());
                Console.WriteLine(currentFile.ReadLine());
                Console.WriteLine(currentFile.ReadLine());
            }
        }

        static void ReadWholeFile(string path) 
        {
            using (StreamReader currentFile = new StreamReader(path))
            {
                //do
                //{
                //    Console.WriteLine($"#:{currentFile.ReadLine()}");
                //} while (!currentFile.EndOfStream);

                while (!currentFile.EndOfStream)
                {
                    Console.WriteLine($"%:{currentFile.ReadLine()}");
                }
                //Console.WriteLine(currentFile.ReadToEnd());
            }
        }

        static int RecordCount(string path)
        {
            int count = 0;
            using (StreamReader currentFile = new StreamReader(path))
            {
                while (!currentFile.EndOfStream)
                {
                    currentFile.ReadLine();
                    count++;
                }
            }

            return count;
        }

        static string[,] ReadFileIntoArray(string path)
        {
            string[,] customerData = new string[5,RecordCount(path)];
            string[] temp;
            int customerNumber = 0;

            using (StreamReader currentFile = new StreamReader(path))
            {
                while (!currentFile.EndOfStream)
                {
                    temp = currentFile.ReadLine().Split(",");
                    customerData[0, customerNumber] = temp[0].Replace("\"$$","");
                    customerData[1, customerNumber] = temp[1];
                    customerData[2, customerNumber] = temp[2];
                    customerData[3, customerNumber] = temp[3].Replace("\"", "");
                    customerData[4, customerNumber] = temp[4];
                    customerNumber++;
                    //Console.WriteLine(temp[0]);
                }   
            }

            return customerData;
        }

        static void DisplayCustomerData(string[,] customerData) 
        {
            string formattedRow = "";
            for (int row = 0; row < customerData.GetLength(1); row++) 
            { 
            
                for ( int column = 0; column < customerData.GetLength(0);column++) 
                {
                    formattedRow += customerData[column,row].PadRight(15) ;
                    //Console.WriteLine(customerData[column,row]);
                }
                Console.WriteLine(formattedRow);
                formattedRow = "";
            }
            
        }


    }
}
