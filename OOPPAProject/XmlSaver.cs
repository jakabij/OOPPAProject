using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace OOPPAProject
{
    class XmlSaver : ISaver
    {
        public void SaveToXml(string path, List<RecipeBook> listOfRecipeBooks)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RecipeBook));
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, listOfRecipeBooks);
            }
        }
    }
}
