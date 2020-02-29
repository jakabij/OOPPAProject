using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OOPPAProject
{
    class XmlLoader : ILoader
    {
        public Store LoadFromXml(string path)
        {
            Store store = new Store();
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            foreach(XmlNode node in xml.DocumentElement) //recipebook
            {
                Console.WriteLine("Name: "+node.ChildNodes[0].InnerText);

                RecipeBook recipeBook = new RecipeBook(node.ChildNodes[0].InnerText);
                foreach (XmlNode node2 in node.ChildNodes[1]) //foods
                {
                    if(node2.Attributes[0].Value.Equals("Appetizer"))
                    {
                        string name=node2.ChildNodes[0].InnerText; 
                        string id=node2.ChildNodes[1].InnerText; 

                        string[] tmp=node2.ChildNodes[2].InnerText.Split(":");
                        TimeSpan preparingTime=new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2])); 

                        bool serveCold=bool.Parse(node2.ChildNodes[3].InnerText); 

                        tmp=node2.ChildNodes[4].InnerText.Split(",");
                        List<string> ingredients = new List<string>();
                        ingredients.AddRange(tmp);  

                        Appetizer food = new Appetizer(id, name, serveCold, ingredients, preparingTime);
                        food.Comment = node2.ChildNodes[5].InnerText;
                        recipeBook.AddFood(food);
                    }
                    else if(node2.Attributes[0].Value.Equals("SecondMeal"))
                    {
                        string name = node2.ChildNodes[0].InnerText; 
                        string id = node2.ChildNodes[1].InnerText; 

                        string[] tmp = node2.ChildNodes[2].InnerText.Split(":");
                        TimeSpan preparingTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2])); 

                        bool needToCook = bool.Parse(node2.ChildNodes[3].InnerText); 

                        bool serveCold = bool.Parse(node2.ChildNodes[4].InnerText); 

                        tmp = node2.ChildNodes[5].InnerText.Split(",");
                        List<string> ingredients = new List<string>();
                        ingredients.AddRange(tmp);  

                        tmp= node2.ChildNodes[6].InnerText.Split(",");
                        List<string> spices = new List<string>();
                        spices.AddRange(tmp);   

                        SecondMeal food = new SecondMeal(id,name,serveCold,ingredients,needToCook,preparingTime,spices);
                        food.Comment = node2.ChildNodes[7].InnerText;
                        recipeBook.AddFood(food);
                    }
                    else if(node2.Attributes[0].Value.Equals("Dessert"))
                    {
                        string name = node2.ChildNodes[0].InnerText; 
                        string id = node2.ChildNodes[1].InnerText; 

                        string[] tmp = node2.ChildNodes[2].InnerText.Split(":");
                        TimeSpan preparingTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2])); 

                        bool needToCook = bool.Parse(node2.ChildNodes[3].InnerText); 

                        bool serveCold = bool.Parse(node2.ChildNodes[4].InnerText); 

                        tmp = node2.ChildNodes[5].InnerText.Split(",");
                        List<string> ingredients = new List<string>();
                        ingredients.AddRange(tmp);  

                        Dessert food = new Dessert(id,name,serveCold,ingredients,needToCook,preparingTime);
                        food.Comment=node2.ChildNodes[6].InnerText;
                        recipeBook.AddFood(food);
                    }
                    else 
                    {
                        throw new Exception("InvalidConverting");
                    }
                }
                store.AddRecipeBook(recipeBook);
            }
            return store;
        }
    }
}
