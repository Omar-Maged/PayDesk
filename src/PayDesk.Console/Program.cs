using PayDesk.Console.Models;

List<Merchant> merchants = new List<Merchant>
{
    new Merchant
    {
        Id = 1,
        Name = "Cairo Market",
        City = "Cairo"
    },

    new Merchant
    {
        Id = 2,
        Name = "Alex Store",
        City = "Alexandria"
    },

    new Merchant
    {
        Id = 3,
        Name = "Giza Shop",
        City = "Giza"
    }

};


Dictionary<int, List<Transaction>> transactions = new Dictionary<int, List<Transaction>>
    {
        {
            1,
            new List<Transaction>
            {
                new Transaction
                {
                    MerchantId = 1,
                    Amount = 1050,
                    Date = DateTime.Today
                },
                new Transaction
                {
                    MerchantId = 1,
                    Amount = 2500,
                    Date = DateTime.Today.AddDays(-1)
                }
            }
        },

        {
            2,
            new List<Transaction>
            {
                new Transaction
                {
                    MerchantId = 2,
                    Amount = 10000,
                    Date = DateTime.Today
                }
            }
        },

        {
            3,
            new List<Transaction>()
        }
    };

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("===== PayDesk =====");
    Console.WriteLine("1. List merchants");
    Console.WriteLine("2. List merchant transactions");
    Console.WriteLine("3. Add transaction");
    Console.WriteLine("4. Show totals per merchant");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            {
                foreach (var merchant in merchants)
                {
                    Console.WriteLine(
                        $"ID: {merchant.Id}, Name: {merchant.Name}, City: {merchant.City}");
                }
                break;
            }

        case 2:
            {
                Console.WriteLine("Enter Merchant ID : ");

                if (!int.TryParse(Console.ReadLine(), out int merchantId))
                {
                    Console.WriteLine("Invalid Merchant ID. ");
                    break;
                }

                var merchant = merchants.FirstOrDefault(m => m.Id == merchantId);

                if (merchant == null)
                {
                    Console.WriteLine("Merchant not found.");
                    break;
                }

                if (!transactions.TryGetValue(merchantId, out var merchantTransactions))
                {
                    Console.WriteLine("No transactions found.");
                    break;
                }

                if (merchantTransactions.Count == 0)
                {
                    Console.WriteLine("No transactions found.");
                    break;
                }

                Console.WriteLine($"Transactions for {merchant.Name}:");

                foreach (var transaction in merchantTransactions)
                {
                    Console.WriteLine(
                        $"{transaction.Amount / 100m:F2} EGP - {transaction.Date:yyyy-MM-dd}");
                }

                break;
            }

        case 3:
            {
                Console.Write("Enter merchant ID: ");

                if (!int.TryParse(Console.ReadLine(), out int transactionMerchantId))
                {
                    Console.WriteLine("Invalid merchant ID.");
                    break;
                }

                var transactionMerchant = merchants.FirstOrDefault(m => m.Id == transactionMerchantId);

                if (transactionMerchant == null)
                {
                    Console.WriteLine("Merchant not found.");
                    break;
                }

                Console.Write("Enter amount in piastres: ");

                if (!long.TryParse(Console.ReadLine(),out long amount))
                {
                    Console.WriteLine("Invalid amount.");
                    break;
                }

                var newTransaction = new Transaction
                {
                    MerchantId = transactionMerchantId,
                    Amount = amount,
                    Date = DateTime.Now
                };

                if (!transactions.ContainsKey(transactionMerchantId))
                {
                    transactions[transactionMerchantId] =
                        new List<Transaction>();
                }

                transactions[transactionMerchantId]
                    .Add(newTransaction);

                Console.WriteLine($"Transaction of {amount / 100m:F2} EGP added successfully.");

                break;
            }

        case 4:
            {
                Console.WriteLine("Totals per merchant:");

                foreach (var merchant in merchants)
                {
                    long total = transactions.ContainsKey(merchant.Id)
                        ? transactions[merchant.Id].Sum(t => t.Amount)
                        : 0;

                    Console.WriteLine(
                        $"{merchant.Name}: {total / 100m:F2} EGP");
                }

                break;
            }

        case 0:
            running = false;
            Console.WriteLine("Goodbye.");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}