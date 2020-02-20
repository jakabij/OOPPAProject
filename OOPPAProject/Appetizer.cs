using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class Appetizer : Food
    {
        public Appetizer(int id, string nameOfFood, bool serveCold, List<string> listOfingredients) : base(id, nameOfFood, serveCold, listOfingredients)
        { }
    }
}
