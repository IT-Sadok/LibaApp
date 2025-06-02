using DocsAndHospitals.Models;
using System.Text.Json;

namespace DocsAndHospitals.Persistence;

public static class HospitalRepository
{
    private static readonly string FilePath = "hospitals.json";

    public static void Save(IEnumerable<Hospital> hospitals)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(hospitals, options);
        File.WriteAllText(FilePath, json);
    }

    public static Hospital[] Load()
    {
        if (!File.Exists(FilePath))
            return Array.Empty<Hospital>();

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<Hospital[]>(json) ?? Array.Empty<Hospital>();
    }
}
