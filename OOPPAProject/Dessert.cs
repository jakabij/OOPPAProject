using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class Dessert : Food
    {
        public bool NeedToCook { get; set; }
        public TimeSpan TimeToPrepare { get; set; }

        public Dessert() { }
        public Dessert(string id, string nameOfFood, bool serveCold, List<string> listOfingredients,bool needToCook,TimeSpan timeToPrepare)
            :base(id, nameOfFood, serveCold, listOfingredients)
        {
            NeedToCook = needToCook;
            TimeToPrepare = timeToPrepare;
        }
    }
}
