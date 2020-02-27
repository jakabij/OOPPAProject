using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public abstract class Food
    {
        public string Id { get; set; }
        public string NameOfFood { get; set; }
        public bool ServeCold { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public string Comment { get; set; }

        public Food() { }
        public Food(string id, string nameOfFood, bool serveCold, List<string> listOfingredients)
        {
            Id = id;
            NameOfFood = nameOfFood;
            ServeCold = serveCold;
            ListOfIngredients = listOfingredients;
        }
    }
}
