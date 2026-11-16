
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Services;

namespace PersonalFinanceManager;

class Program
{
    static void Main(string[] args)
    {
        FinanceManager manager = new FinanceManager();
        JsonStorage storage = new JsonStorage();

        // Load previously saved information
        var savedData = storage.LoadData();

        manager.LoadData(savedData.Item1, savedData.Item2);

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("==============================");
            Console.WriteLine(" PERSONAL FINANCE MANAGER");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View Transactions");
            Console.WriteLine("3. Search Transactions");
            Console.WriteLine("4. Edit Transaction");
            Console.WriteLine("5. Delete Transaction");
            Console.WriteLine("6. Manage Budgets");
            Console.WriteLine("7. Financial Summary");
            Console.WriteLine("8. View Spending by Category");
            Console.WriteLine("9. Save Data");
            Console.WriteLine("0. Save and Exit");
            Console.WriteLine("==============================");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddTransaction(manager);
                    break;

                case "2":
                    manager.ViewTransactions();
                    Pause();
                    break;

                case "3":
                    SearchTransactions(manager);
                    break;

                case "4":
                    Console.WriteLine("Edit functionality to be implemented.");
                    Pause();
                    break;

                case "5":
                    Console.WriteLine("Delete functionality to be implemented.");
                    Pause();
                    break;

                case "6":
                    ManageBudget(manager);
                    break;

                case "7":
                    DisplaySummary(manager);
                    break;

                case "8":
                    manager.DisplayExpensesByCategory();
                    Pause();
                    break;

                case "9":
                    Save(manager, storage);
                    Pause();
                    break;

                case "0":
                    Save(manager, storage);
                    running = false;
                    Console.WriteLine("Thank you for using Personal Finance Manager.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Pause();
                    break;
            }
        }
    }

    static void AddTransaction(FinanceManager manager)
    {
        Console.Clear();
        Console.WriteLine("ADD TRANSACTION");

        Console.Write("Transaction ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            Pause();
            return;
        }

        Console.Write("Date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(
            Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date.");
            Pause();
            return;
        }

        Console.Write("Type (Income/Expense): ");
        string typeInput = Console.ReadLine() ?? "";

        if (!Enum.TryParse(
            typeInput, true, out TransactionType type) ||
            !Enum.IsDefined(type))
        {
            Console.WriteLine("Invalid transaction type.");
            Pause();
            return;
        }

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? "";

        Console.Write("Amount: ");
        if (!decimal.TryParse(
            Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount.");
            Pause();
            return;
        }

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Transaction transaction = new Transaction
        {
            TransactionId = id,
            Date = date,
            Type = type,
            Category = category,
            Amount = amount,
            Description = description
        };

        try
        {
            manager.AddTransaction(transaction);
            Console.WriteLine("Transaction added.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Pause();
    }

    static void SearchTransactions(FinanceManager manager)
    {
        Console.Write("Enter category to search: ");
        string category = Console.ReadLine() ?? "";

        var results = manager.SearchByCategory(category);

        if (results.Count == 0)
        {
            Console.WriteLine("No transactions found.");
        }
        else
        {
            foreach (var transaction in results)
            {
                Console.WriteLine(
                    $"{transaction.TransactionId} | " +
                    $"{transaction.Category} | " +
                    $"{transaction.Amount:C}");
            }
        }

        Pause();
    }

    static void ManageBudget(FinanceManager manager)
    {
        Console.Write("Enter budget category: ");
        string category = Console.ReadLine() ?? "";

        Console.Write("Enter monthly budget: ");

        if (!decimal.TryParse(
            Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount.");
            Pause();
            return;
        }

        try
        {
            manager.SetBudget(category, amount);
            Console.WriteLine("Budget updated.");
            manager.CheckBudgets();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Pause();
    }

    static void DisplaySummary(FinanceManager manager)
    {
        Console.WriteLine("\nFINANCIAL SUMMARY");
        Console.WriteLine("------------------------------");

        Console.WriteLine($"Total Income: {manager.CalculateIncome():C}");
        Console.WriteLine($"Total Expenses: {manager.CalculateExpenses():C}");
        Console.WriteLine($"Net Balance: {manager.CalculateBalance():C}");

        Console.WriteLine("------------------------------");

        Pause();
    }

    static void Save(FinanceManager manager, JsonStorage storage)
    {
        storage.SaveData(
            manager.GetTransactions(),
            manager.GetBudgets());
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
