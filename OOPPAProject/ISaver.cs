using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    interface ISaver
    {
        void SaveToXml(string path,List<RecipeBook> listOfRecipeBooks);
    }
}
