
namespace PersonalFinanceManager.Models;

public class Transaction
{
    public int TransactionId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public string Category { get; set; } = "";
    public decimal Amount { get; set; }
    public string Description { get; set; } = "";

    public Transaction() { }
}
