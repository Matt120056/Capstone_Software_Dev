
namespace PersonalFinanceManager.Models;

public class Budget
{
    public string Category { get; set; } = "";
    public decimal MonthlyLimit { get; set; }

    public Budget() { }
}
