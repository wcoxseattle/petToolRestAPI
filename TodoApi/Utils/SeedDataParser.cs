using Newtonsoft.Json;
using PetToolAPI.Models;

using Microsoft.EntityFrameworkCore;


namespace PetToolAPI.Utils
{
    public class SeedDataParser
    {
        private string _filePath;
        private SeedData _seedData;

        public SeedDataParser(string filePath) 
        {
            _filePath = filePath;
        }


        /// <summary>
        /// Loads JSON file content from the specified file.
        /// </summary>
        public void LoadSeedData()
        {
            using (StreamReader r = new StreamReader(_filePath))
            {
                string jsonFileContent = r.ReadToEnd();
                SeedData _seedData = JsonConvert.DeserializeObject<SeedData>(jsonFileContent);
            }
        }


        public void SeedData(ModelBuilder modelBuilder)
        {
            // check against db
        } 

    }
}
