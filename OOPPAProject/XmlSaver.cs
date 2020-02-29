using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OOPPAProject
{
    public class XmlSaver : ISaver
    {
        public void SaveToXml(string path, List<RecipeBook> listOfRecipeBooks)
        {
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            writer.WriteStartElement("Store");
            foreach (var book in listOfRecipeBooks)
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("RecipeBook");
                writer.WriteElementString("Name",book.NameOfBook);
                writer.WriteStartElement("Foods");
                foreach(var food in book.ListOfFoods)
                {
                    writer.WriteStartElement("Food");
                    if(food is Appetizer)
                    {
                        Appetizer appetizer = (Appetizer)food;
                        writer.WriteAttributeString("Type", "Appetizer");
                        writer.WriteElementString("FoodName", appetizer.NameOfFood);
                        writer.WriteElementString("ID", appetizer.Id);
                        writer.WriteElementString("PreparingTime", appetizer.TimeToPrepare.ToString());
                        writer.WriteElementString("ServeCold", appetizer.ServeCold.ToString());

                        string ingredients = "";
                        for (int i = 0; i < appetizer.ListOfIngredients.Count; i++)
                        {
                            if (i != appetizer.ListOfIngredients.Count - 1)
                                ingredients += appetizer.ListOfIngredients[i] + ",";
                            else
                                ingredients += appetizer.ListOfIngredients[i];
                        }
                        writer.WriteElementString("Ingredients", ingredients);
                        writer.WriteElementString("Comment", appetizer.Comment);
                    }
                    else if(food is SecondMeal)
                    {
                        SecondMeal secondMeal = (SecondMeal)food;
                        writer.WriteAttributeString("Type", "SecondMeal");
                        writer.WriteElementString("FoodName", secondMeal.NameOfFood);
                        writer.WriteElementString("ID", secondMeal.Id);
                        writer.WriteElementString("PreparingTime", secondMeal.TimeToPrepare.ToString());
                        writer.WriteElementString("NeedToCook", secondMeal.NeedToCook.ToString());
                        writer.WriteElementString("ServeCold", secondMeal.ServeCold.ToString());

                        string ingredients = "";
                        for(int i=0;i< secondMeal.ListOfIngredients.Count;i++)
                        {
                            if (i != secondMeal.ListOfIngredients.Count - 1)
                                ingredients += secondMeal.ListOfIngredients[i] + ",";
                            else
                                ingredients += secondMeal.ListOfIngredients[i];
                        }
                        writer.WriteElementString("Ingredients", ingredients);

                        ingredients = "";

                        for (int i = 0; i < secondMeal.ListOfSpices.Count; i++)
                        {
                            if (i != secondMeal.ListOfSpices.Count - 1)
                                ingredients += secondMeal.ListOfSpices[i] + ",";
                            else
                                ingredients += secondMeal.ListOfSpices[i];
                        }
                        writer.WriteElementString("Spices", ingredients);

                        writer.WriteElementString("Comment", secondMeal.Comment);                       
                    }
                    else if(food is Dessert)
                    {
                        Dessert dessert = (Dessert)food;
                        writer.WriteAttributeString("Type", "Dessert");
                        writer.WriteElementString("FoodName", dessert.NameOfFood);
                        writer.WriteElementString("ID", dessert.Id);
                        writer.WriteElementString("PreparingTime", dessert.TimeToPrepare.ToString());
                        writer.WriteElementString("NeedToCook", dessert.NeedToCook.ToString());
                        writer.WriteElementString("ServeCold", dessert.ServeCold.ToString());

                        string ingredients = "";
                        foreach (var item in dessert.ListOfIngredients)
                        {
                            ingredients += item;
                        }
                        writer.WriteElementString("Ingredients", ingredients);
                        writer.WriteElementString("Comment", dessert.Comment);
                    }
                    writer.WriteEndElement(); //Food
                }
                writer.WriteEndElement(); //Foods
                writer.WriteEndElement(); //RecipeBook
            }
            writer.WriteEndElement(); //Store
            writer.Close();
        }
    }
}
