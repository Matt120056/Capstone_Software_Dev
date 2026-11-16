
using System.Text.Json;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services;

public class JsonStorage
{
    private readonly string filePath = "Data/finance-data.json";

    private class FinanceData
    {
        public List<Transaction> Transactions { get; set; } = new();
        public Dictionary<string, Budget> Budgets { get; set; } = new();
    }

    public void SaveData(
        List<Transaction> transactions,
        Dictionary<string, Budget> budgets)
    {
        try
        {
            Directory.CreateDirectory("Data");

            var data = new FinanceData
            {
                Transactions = transactions,
                Budgets = budgets
            };

            string json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);

            Console.WriteLine("Data saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Unable to save data: {ex.Message}");
        }
    }

    public (List<Transaction>, Dictionary<string, Budget>) LoadData()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return (new List<Transaction>(),
                        new Dictionary<string, Budget>());
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return (new List<Transaction>(),
                        new Dictionary<string, Budget>());
            }

            var data = JsonSerializer.Deserialize<FinanceData>(json);

            return (
                data?.Transactions ?? new List<Transaction>(),
                data?.Budgets ?? new Dictionary<string, Budget>()
            );
        }
        catch (JsonException)
        {
            Console.WriteLine("Warning: JSON file is invalid.");
            return (new List<Transaction>(),
                    new Dictionary<string, Budget>());
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Unable to load data: {ex.Message}");
            return (new List<Transaction>(),
                    new Dictionary<string, Budget>());
        }
    }
}
