using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class Appetizer : Food
    {
        public TimeSpan TimeToPrepare { get; set; }

        public Appetizer() { }
        public Appetizer(string id, string nameOfFood, bool serveCold, List<string> listOfingredients, TimeSpan timeToPrepare)
            : base(id, nameOfFood, serveCold, listOfingredients)
        {
            TimeToPrepare = timeToPrepare;
        }
    }
}
