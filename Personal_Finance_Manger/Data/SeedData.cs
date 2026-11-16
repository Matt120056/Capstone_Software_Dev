
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Data;

public static class SeedData
{
    public static List<Transaction> GetTransactions()
    {
        return new List<Transaction>
        {
            new() { TransactionId = 1, Date = new(2026, 11, 1), Type = TransactionType.Income, Category = "Salary", Amount = 2800m, Description = "Monthly salary" },
            new() { TransactionId = 2, Date = new(2026, 11, 2), Type = TransactionType.Expense, Category = "Housing", Amount = 950m, Description = "Monthly rent" },
            new() { TransactionId = 3, Date = new(2026, 11, 3), Type = TransactionType.Expense, Category = "Groceries", Amount = 125m, Description = "Weekly groceries" },
            new() { TransactionId = 4, Date = new(2026, 11, 4), Type = TransactionType.Expense, Category = "Transportation", Amount = 65m, Description = "Fuel" },
            new() { TransactionId = 5, Date = new(2026, 11, 5), Type = TransactionType.Expense, Category = "Entertainment", Amount = 45m, Description = "Movie night" },
            new() { TransactionId = 6, Date = new(2026, 11, 6), Type = TransactionType.Expense, Category = "Utilities", Amount = 110m, Description = "Electricity bill" },
            new() { TransactionId = 7, Date = new(2026, 11, 7), Type = TransactionType.Income, Category = "Other", Amount = 150m, Description = "Freelance work" },
            new() { TransactionId = 8, Date = new(2026, 11, 8), Type = TransactionType.Expense, Category = "Groceries", Amount = 80m, Description = "Food shopping" },
            new() { TransactionId = 9, Date = new(2026, 11, 9), Type = TransactionType.Expense, Category = "Healthcare", Amount = 35m, Description = "Pharmacy" },
            new() { TransactionId = 10, Date = new(2026, 11, 10), Type = TransactionType.Expense, Category = "Transportation", Amount = 55m, Description = "Gas" },
            new() { TransactionId = 11, Date = new(2026, 11, 11), Type = TransactionType.Expense, Category = "Entertainment", Amount = 75m, Description = "Concert tickets" },
            new() { TransactionId = 12, Date = new(2026, 11, 12), Type = TransactionType.Expense, Category = "Groceries", Amount = 95m, Description = "Weekly groceries" },
            new() { TransactionId = 13, Date = new(2026, 11, 13), Type = TransactionType.Expense, Category = "Utilities", Amount = 60m, Description = "Internet bill" },
            new() { TransactionId = 14, Date = new(2026, 11, 14), Type = TransactionType.Expense, Category = "Other", Amount = 40m, Description = "Household supplies" },
            new() { TransactionId = 15, Date = new(2026, 11, 15), Type = TransactionType.Income, Category = "Other", Amount = 100m, Description = "Gift received" }
        };
    }
}
