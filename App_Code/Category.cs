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
        //вместо Console.WriteLine(root.name + " - " + root.parent);
        //запрос
        //select book.name, book.author, book.publishing, book.info 
        //from book, book_category, category 
        //where book.Id_book=book_category.id_book 
        //and category.id_category=book_category.id_category
        //and category.category=root

        if (root.name == "") xml += "<All_Books>";
        else xml += "<" + root.name + ">";
        Console.WriteLine(root.name + " - " + root.parent);
        foreach (Category c in root.subCategories)
        {
            print(c);
        }
        if (root.name == "") xml += "</All_Books>"; 
        else xml += "</" + root.name + ">";
        return xml;
    }



}
