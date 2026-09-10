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