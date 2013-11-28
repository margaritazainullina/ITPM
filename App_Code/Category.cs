using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Category
{
    String name;
    String parent;
    List<Category> subCategories = new List<Category>();

    String xml = "";

    public Category(String name, String parent)
    {
        this.name = name;
        this.parent = parent;
    }

    public void add(String cat, String parent, Category root)
    {
        if (root.name.ToString() == parent) root.subCategories.Add(new Category(cat, parent));
        else foreach (Category c in root.subCategories)
            {
                add(cat, parent, c);
            }
    }
 
    public String print(Category root)
    {
        if (root.name == "")
        {
            xml += "<Все_книги_сайта>";
                  }
        else xml += "<" + root.name + ">";
        Console.WriteLine(root.name + " - " + root.parent);
        foreach (Category c in root.subCategories)
        {
            print(c);
        }
        if (root.name == "") xml += "</Все_книги_сайта>"; 
        else xml += "</" + root.name + ">";
        //some magic
        return xml.Replace("<Все_книги_сайта></Все_книги_сайта>","");     
    }



}
