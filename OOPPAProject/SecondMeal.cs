using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    public class SecondMeal : Food
    {
        public bool NeedToCook { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public List<string> ListOfSpices { get; set; }
        public SecondMeal(int id, string nameOfFood, bool serveCold, List<string> listOfingredients
            ,bool needToCook, TimeSpan timeToPrepare, List<string> listOfSpices)
            :base(id, nameOfFood, serveCold, listOfingredients)
        {
            NeedToCook = needToCook;
            TimeToPrepare = timeToPrepare;
            ListOfSpices = listOfSpices;
        }
    }
}
