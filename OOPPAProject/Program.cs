using System;
using System.Collections.Generic;

namespace OOPPAProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            RecipeBook r = new RecipeBook("ABCD123", "Cook From It", 10);
            r.AddFood(r.CreateFood("1", "meat", true, new List<string> { "a", "b" }));

            RecipeBook r2 = new RecipeBook("ABCD124", "Cook", 5);
            r2.AddFood(r2.CreateFood("1", "meat", false, new List<string> { "b" }));

            //RecipeBook r3 = m.CreateRecipeBook();

            Store s = new Store();
            s.AddRecipeBook(r);
            s.AddRecipeBook(r2);
            //s.AddRecipeBook(r3);

            m.PrintAllBooks(s.ListOfRecipeBooks);
            Console.WriteLine("\n");
            //m.ShowRecepeByFoodId("ABCD123", s);

            m.ShowRecepeByFoodId("ABCD123", s);
            //m.ShowRecepeByFoodName("meat", s);
        }
    }
}
