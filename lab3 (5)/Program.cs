class Prices {
    public int Drink;
    public int Snack;
    public int Meal;
}

class Choices {
    public int DrinkQuantity;                           
    public int SnackQuantity;
    public int MealQuantity;
}

class Orders {
    static void Main() {
        Prices prices = new Prices {
            Drink = 2,
            Snack = 3,
            Meal = 5
        };
        Choices client1 = new Choices {
            DrinkQuantity = 1,
            SnackQuantity = 0,
            MealQuantity = 1
        };
        
        Choices client2 = new Choices {
            DrinkQuantity = 2,
            SnackQuantity = 2,
            MealQuantity = 0
        };
        int total1 = CustomerTotal(prices, client1);
        Console.WriteLine($"Debug: Prices after client 1 total calculation - Drink: {prices.Drink}");
        int total2 = CustomerTotal(prices, client2);

        Console.WriteLine($"Client 1 total: ${total1}");
        Console.WriteLine($"Client 2 total: ${total2}");
        Console.WriteLine($"Combined total: ${total1 + total2}");
    }

    static int CustomerTotal(Prices prices, Choices choices) {
        prices.Drink = 3;
        return (prices.Drink * choices.DrinkQuantity) +
               (prices.Snack * choices.SnackQuantity) +
               (prices.Meal * choices.MealQuantity);
    }
}
