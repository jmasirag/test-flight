using ABC.Repository.Schema;
using System.Text.Json;

namespace ABC.Repository
{
    public class ABCDatabase : IABCDatabase
    {
        private List<DFWGateLoungeFlight> _dfWGateLoungeFlight;

        public ABCDatabase() {
            _dfWGateLoungeFlight = GetGateLoungerFlightRecords();
        }

        public List<DFWGateLoungeFlight> DFWGateLoungeFlight { get => _dfWGateLoungeFlight;  }

        private List<DFWGateLoungeFlight>? GetGateLoungerFlightRecords()
        {
            string filePathInBin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\rawData.json");


            string jsonContent = ReadJsonFromFile(filePathInBin);

            if (jsonContent != null)
            {
                MainObject obj =  JsonSerializer.Deserialize<MainObject>(jsonContent);

                if(obj != null) 
                    return obj.DFWGateLoungeFlightList;
            }
            
           return new List<DFWGateLoungeFlight>();
        }

        static string ReadJsonFromFile(string filePath)
        {
            try
            { 
                if (File.Exists(filePath))
                {
                 
                    return File.ReadAllText(filePath);
                }
                else
                {
                    Console.WriteLine("File not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                return null;
            }
        }
    }
}