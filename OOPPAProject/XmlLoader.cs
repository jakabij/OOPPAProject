using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace OOPPAProject
{
    class XmlLoader : ILoader
    {
        public List<RecipeBook> LoadFromXml(string path)
        {
            List<RecipeBook> listOfRecepes=new List<RecipeBook>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RecipeBook>));
            using (StreamReader streamReader = new StreamReader(path))
            {
                listOfRecepes=(List<RecipeBook>)xmlSerializer.Deserialize(streamReader);
            }
            return listOfRecepes;
        }
    }
}
