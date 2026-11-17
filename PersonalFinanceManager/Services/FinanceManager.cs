//I Did my best to explain every section for yall
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services;

public class FinanceManager
{
    // Store transactions dynamically
    private List<Transaction> transactions = new();

    // Store budgets using category names
    private Dictionary<string, Budget> budgets = new();

    private readonly string[] supportedCategories =
    {
        "Housing",
        "Groceries",
        "Transportation",
        "Entertainment",
        "Utilities",
        "Healthcare",
        "Salary",
        "Other"
    };

    public List<Transaction> GetTransactions()
    {
        return transactions;
    }

    // ADD TRANSACTION
    public void AddTransaction(Transaction transaction)
    {
        //For Either elizabeth or priscilla 
        // TODO: Validate amount
        // TODO: Validate date
        // TODO: Check duplicate ID
        // TODO: Validate category

        transactions.Add(transaction);
    }

    // VIEW TRANSACTIONS
    public void ViewTransactions()
    {
        foreach (var transaction in transactions)
        {
            Console.WriteLine(
                $"{transaction.TransactionId} | " +
                $"{transaction.Date:d} | " +
                $"{transaction.Type} | " +
                $"{transaction.Category} | " +
                $"{transaction.Amount:C} | " +
                $"{transaction.Description}"
            );
        }
    }

    // SEARCH TRANSACTIONS
    public List<Transaction> SearchByCategory(string category)
    {
        return transactions
            .Where(t => t.Category.Equals(
                category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // FILTER BY TYPE
    public List<Transaction> FilterByType(TransactionType type)
    {
        return transactions
            .Where(t => t.Type == type)
            .ToList();
    }

    // SORT BY AMOUNT
    public List<Transaction> SortByAmount()
    {
        return transactions
            .OrderByDescending(t => t.Amount)
            .ToList();
    }

    // TOTAL INCOME
    public decimal CalculateIncome()
    {
        return transactions
            .Where(t => t.Type == TransactionType.Income)
            .Sum(t => t.Amount);
    }

    // TOTAL EXPENSES
    public decimal CalculateExpenses()
    {
        return transactions
            .Where(t => t.Type == TransactionType.Expense)
            .Sum(t => t.Amount);
    }

    // NET BALANCE
    public decimal CalculateBalance()
    {
        return CalculateIncome() - CalculateExpenses();
    }

    // GROUP EXPENSES BY CATEGORY
    public void DisplayExpensesByCategory()
    {
        var results = transactions
            .Where(t => t.Type == TransactionType.Expense)
            .GroupBy(t => t.Category);

        foreach (var group in results)
        {
            Console.WriteLine(
                $"{group.Key}: {group.Sum(t => t.Amount):C}");
        }
    }

    // SET CATEGORY BUDGET
    public void SetBudget(string category, decimal amount)
    {
        // TODO: Validate category and amount

        budgets[category] = new Budget
        {
            Category = category,
            MonthlyLimit = amount
        };
    }

    // CHECK BUDGET
    public void CheckBudgets()
    {
        foreach (var budget in budgets.Values)
        {
            decimal spent = transactions
                .Where(t =>
                    t.Type == TransactionType.Expense &&
                    t.Category.Equals(
                        budget.Category,
                        StringComparison.OrdinalIgnoreCase))
                .Sum(t => t.Amount);

            Console.WriteLine(
                $"{budget.Category}: {spent:C} / {budget.MonthlyLimit:C}");

            if (spent > budget.MonthlyLimit)
            {
                Console.WriteLine("WARNING: Budget exceeded!");
            }
        }
    }

    // EDIT TRANSACTION
    public void EditTransaction(int id)
    {
        //For Either elizabeth or priscilla 
        // TODO: Find transaction by ID
        // TODO: Request updated information
        // TODO: Validate changes
    }

    // DELETE TRANSACTION
    public void DeleteTransaction(int id)
    {
        //For Either elizabeth or priscilla 
        // TODO: Find transaction by ID
        // TODO: Remove transaction
    }

    // ACCESS BUDGETS
    public Dictionary<string, Budget> GetBudgets()
    {
        return budgets;
    }

    // LOAD DATA INTO MANAGER
    public void LoadData(
        List<Transaction> loadedTransactions,
        Dictionary<string, Budget> loadedBudgets)
    {
        transactions = loadedTransactions;
        budgets = loadedBudgets;
    }
}
