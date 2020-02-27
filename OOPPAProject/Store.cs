using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class Store
    {
        public List<RecipeBook> ListOfRecipeBooks { get; set; }

        public Store()
        {
            ListOfRecipeBooks = new List<RecipeBook>();
        }

        public void AddRecipeBook(RecipeBook recipeBook)
        {
            ListOfRecipeBooks.Add(recipeBook);
        }

        public bool RemoveRecipeBook(string id)
        {
            foreach(var book in ListOfRecipeBooks)
            {
                if(book.Id.Equals(id))
                {
                    ListOfRecipeBooks.Remove(book);
                    return true;
                }
            }
            return false;
        }
    }
}
