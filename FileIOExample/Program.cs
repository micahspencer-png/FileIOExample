namespace FileIOExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "TestFile.txt";
            WriteToFile(filePath);
            
            //Console.Read();
        }

        static void WriteToFile(string path) 
        {
            using (StreamWriter currentFile = File.CreateText(path))
            {
                currentFile.WriteLine("Wake up Neo. . .");
            }
        }
    }
}
