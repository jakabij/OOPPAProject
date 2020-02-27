﻿using System;
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
            foreach(var book in listOfRecipeBooks)
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("Store");
                writer.WriteStartElement("RecipeBook");
                writer.WriteElementString("Name",book.NameOfBook);
                writer.WriteStartElement("Foods");
                foreach(var food in book.ListOfFoods)
                {
                    if(food is Appetizer)
                    {
                        Appetizer appetizer = (Appetizer)food;
                        writer.WriteElementString("FoodType", "Appetizer");
                        writer.WriteElementString("FoodName", appetizer.NameOfFood);
                        writer.WriteElementString("ID", appetizer.Id);
                        writer.WriteElementString("PreparingTime", appetizer.TimeToPrepare.ToString());
                    }
                    else if(food is SecondMeal)
                    {
                        SecondMeal secondMeal = (SecondMeal)food;
                        writer.WriteElementString("FoodType", "SecondMeal");
                        writer.WriteElementString("FoodName", secondMeal.NameOfFood);
                        writer.WriteElementString("ID", secondMeal.Id);
                        writer.WriteElementString("PreparingTime", secondMeal.TimeToPrepare.ToString());
                    }
                    else if(food is Dessert)
                    {
                        Dessert dessert = (Dessert)food;
                        writer.WriteElementString("FoodType", "Dessert");
                        writer.WriteElementString("FoodName", dessert.NameOfFood);
                        writer.WriteElementString("ID", dessert.Id);
                        writer.WriteElementString("PreparingTime", dessert.TimeToPrepare.ToString());
                    }
                }
                writer.WriteEndElement(); //Foods
                writer.WriteEndElement(); //BookName
                writer.WriteEndElement(); //RecipeBook
            }
            writer.Close();
            /*
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RecipeBook>));
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, listOfRecipeBooks);
            }
            */
        }
    }
}
