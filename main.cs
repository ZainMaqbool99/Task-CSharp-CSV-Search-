using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3)
            {
                throw new Exception("Kindly follow the pattern to run: name.exe FilePath ColumnIndex SearchDataKey");
            }

            string filePath = args[0];
            int columnIndex = int.Parse(args[1]);
            string searchDataKey = args[2];

            if (!File.Exists(filePath))
            {
                throw new Exception("CSV File Does Not Exists At The Given Path!");
            }

            string resultRow = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    string[] rowDataSplit = row.Split(',');

                    if (rowDataSplit.Length > columnIndex && rowDataSplit[columnIndex].Trim().Equals(searchDataKey, StringComparison.OrdinalIgnoreCase))
                    {
                        resultRow = row;
                        break;
                    }
                }

                if(!string.IsNullOrEmpty(resultRow))
                { Console.WriteLine(resultRow); }
                else
                { Console.WriteLine("No Data Found!"); }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
