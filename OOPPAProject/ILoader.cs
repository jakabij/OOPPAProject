using System;
using System.Collections.Generic;
using System.Text;

namespace OOPPAProject
{
    interface ILoader
    {
        List<RecipeBook> LoadFromXml(string path);
    }
}
