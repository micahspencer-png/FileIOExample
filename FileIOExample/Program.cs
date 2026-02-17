namespace FileIOExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\..\\TestFile.txt";
            //WriteToFile(filePath);
            //AppendToFile(filePath);
            //ReadFromFile(filePath);
            ReadWholeFile(filePath);

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

                //while (!currentFile.EndOfStream)
                //{
                //    Console.WriteLine($"%:{currentFile.ReadLine()}");
                //}
                Console.WriteLine(currentFile.ReadToEnd());
            }
        }
    }
}
