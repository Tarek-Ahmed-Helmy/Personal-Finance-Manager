
namespace PersonalFinanceManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceManager manager = new FinanceManager();

            while (true)
            {
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. Edit Transaction");
                Console.WriteLine("4. Delete Transaction");
                Console.WriteLine("5. View Report");
                Console.WriteLine("6. Save Data");
                Console.WriteLine("7. Load Data");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction(manager);
                        break;
                    case "2":
                        ViewTransactions(manager);
                        break;
                    case "3":
                        EditTransaction(manager);
                        break;
                    case "4":
                        DeleteTransaction(manager);
                        break;
                    case "5":
                        ViewReport(manager);
                        break;
                    case "6":
                        SaveData(manager);
                        break;
                    case "7":
                        LoadData(manager);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine("\n---------------------------------------------\n");
            }
        }

        static void AddTransaction(FinanceManager manager)
        {
            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter category (cash/visa): ");
            string category = Console.ReadLine();
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter type (income/expenses): ");
            string type = Console.ReadLine();
            while (!type.Equals("income") && !type.Equals("expenses"))
            {
                Console.Write("Enter type with correct format (income/expenses): ");
                type = Console.ReadLine();
            }

            Transaction transaction = new Transaction(date, category, type, amount);
            manager.AddTransaction(transaction);
        }

        static void ViewTransactions(FinanceManager manager)
        {
            List<Transaction> transactions = manager.GetTransactions();
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {transactions[i]}");
            }
        }

        static void EditTransaction(FinanceManager manager)
        {
            Console.Write("Enter transaction number to edit: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter new date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter new category: ");
            string category = Console.ReadLine();
            Console.Write("Enter new amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter new type (Income/Expense): ");
            string type = Console.ReadLine();

            Transaction newTransaction = new Transaction(date, category, type, amount);
            manager.EditTransaction(index, newTransaction);
        }

        static void DeleteTransaction(FinanceManager manager)
        {
            Console.Write("Enter transaction number to delete: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            manager.DeleteTransaction(index);
        }

        static void ViewReport(FinanceManager manager)
        {
            decimal totalIncome = manager.GetTotalIncome();
            decimal totalExpenses = manager.GetTotalExpenses();
            decimal netSavings = manager.GetNetSavings();

            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Net Savings: {netSavings:C}");
        }

        static void SaveData(FinanceManager manager)
        {
            Console.Write("Enter file name to save: ");
            string fileName = Console.ReadLine();
            manager.SaveToFile(fileName);
        }

        static void LoadData(FinanceManager manager)
        {
            Console.Write("Enter file name to load: ");
            string fileName = Console.ReadLine();
            manager.LoadFromFile(fileName);
        }
    }
}
