// Запрограммируйте класс Money (объект класса оперирует одной валютой) для работы с деньгами.
// В классе должны быть предусмотрены поле для хранения целой части денег (доллары, евро, гривны и т.д.)
// и поле для хранения копеек (центы, евроценты, копейки и т.д.). Реализовать методы для вывода
// суммы на экран, задания значений для частей. На базе класса Money создать класс Product для работы
// с продуктом или товаром. Реализовать метод, позволяющий уменьшить цену на заданное число.
// Для каждого из классов реализовать необходимые методы и поля.

class Money
{
    public int Dollars { get; set; }
    public int Cents { get; set; }

    public Money(int dollars, int cents)
    {
        Dollars = dollars;
        Cents = cents;
    }

    public void DisplayAmount()
    {
        Console.WriteLine($"{Dollars}.{Cents:D2} баксов");
    }
}

class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void DecreasePrice(int reductionDollars, int reductionCents)
    {
        Price.Dollars -= reductionDollars;
        Price.Cents -= reductionCents;

        while (Price.Cents < 0)
        {
            Price.Dollars--;
            Price.Cents += 100;
        }

        if (Price.Dollars < 0)
        {
            Price.Dollars = 0;
            Price.Cents = 0;
        }
    }

    public void DisplayProductInfo()
    {
        Console.WriteLine($"Продукт: {Name}");
        Console.Write("Цена: ");
        Price.DisplayAmount();
    }
}

class Program
{
    static void Main()
    {
        Money initialPrice = new Money(10, 50);
        Product product = new Product("Пример продукта", initialPrice);

        Console.WriteLine("Исходная информация о продукте:");
        product.DisplayProductInfo();
      
        product.DecreasePrice(2, 25);

        Console.WriteLine("\nИнформация о продукте после снижения цен:");
        product.DisplayProductInfo();
    }
}
