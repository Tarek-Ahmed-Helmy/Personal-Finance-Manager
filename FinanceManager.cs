using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalFinanceManager
{
    internal class FinanceManager
    {
        List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public void DeleteTransaction(int index)
        {
            if (index < transactions.Count && index >= 0)
            {
                transactions.RemoveAt(index);
            }
        }

        public void EditTransaction (int index, Transaction transaction)
        {
            if(index < transactions.Count && index >= 0)
            {
                transactions[index] = transaction;
            }
        }

        public List<Transaction> GetTransactions() 
        {
            return transactions; 
        }

        public decimal GetTotalIncome()
        {
            decimal total = 0;
            foreach (var transaction in transactions)
            {
                if (transaction.Type == "income")
                {
                    total += transaction.Amount;
                }
            }
            return total;
        }

        public decimal GetTotalExpenses()
        {
            decimal total = 0;
            foreach(var transaction in transactions)
            {
                if(transaction.Type == "expenses")
                {
                    total += transaction.Amount;
                }
            }
            return total;
        }

        public decimal GetNetSavings()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }

        public void SaveToFile(string fileName)
        {
            try
            {
                // Ensure the directory exists
                string directory = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Write the header line
                    writer.WriteLine("Date,Category,Amount,Type");

                    // Write each transaction as a CSV line
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine($"{transaction.Date:yyyy-MM-dd},{transaction.Category},{transaction.Amount},{transaction.Type}");
                    }
                }

                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving data: {ex.Message}");
            }
        }


        public void LoadFromFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    transactions.Clear();

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        // Skip the header line
                        reader.ReadLine();

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] fields = line.Split(',');

                            DateTime date = DateTime.Parse(fields[0]);
                            string category = fields[1];
                            decimal amount = decimal.Parse(fields[2]);
                            string type = fields[3];

                            Transaction transaction = new Transaction(date, category, type, amount);
                            transactions.Add(transaction);
                        }
                    }

                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File not found. Please check the file name and try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data: {ex.Message}");
            }
        }

    }


}
