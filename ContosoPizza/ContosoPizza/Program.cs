using ContosoPizza.Data;
using ContosoPizza.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using ContosoPizzaContext context = new ContosoPizzaContext();

        // Delete Data.

        var pizza = context.Products
            .Where(p => p.Name == "Pizza")
            .FirstOrDefault();

        if (pizza is Product)
        {
            context.Remove(pizza);
        }

        context.SaveChanges();

        // Update Data.
        //var veggieSpecial = context.Products
        //    .Where(p => p.Name == "Veggie Special Pizza")
        //    .FirstOrDefault();

        //if (veggieSpecial is Product)
        //{
        //    veggieSpecial.Price = 10.99M;
        //}

        //context.SaveChanges();

        // LINQ Syntaxe.
        var products = from product in context.Products
                       where product.Price > 10.00M
                       orderby product.Name
                       select product;


        // Fluent API Syntaxe.
        //var products = context.Products
        //    .Where(p => p.Price > 10.00M)
        //    .OrderBy(p => p.Name);

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        // Save Data.
        //Product veggieSpecial = new Product()
        //{
        //    Name = "Veggie Special Pizza",
        //    Price = 9.99M
        //};
        //context.Products.Add(veggieSpecial);

        //Product deluxMeat = new Product()
        //{
        //    Name = "Delux Meat Pizza",
        //    Price = 12.99M
        //};
        //context.Products.Add(deluxMeat);

        //context.SaveChanges();
    }
}