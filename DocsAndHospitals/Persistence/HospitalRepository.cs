using DocsAndHospitals.Models;
using System.Text.Json;

namespace DocsAndHospitals.Persistence
{
    public class JsonHospitalRepository : IHospitalRepository
    {
        private readonly string _filePath;
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public JsonHospitalRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<Hospital>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Hospital>();

            string json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Hospital>>(json, _options) ?? new List<Hospital>();
        }


        public async Task SaveAsync(IEnumerable<Hospital> hospitals)
        {
            string json = JsonSerializer.Serialize(hospitals, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }

    }

}
