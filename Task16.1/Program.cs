using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16._1
{
    public class Product
    {
        public int code { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        public Product(int code, string name, float price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }
    }
    internal class Program
    {
        static void Main()
        {
            int newcode = 0;
            string newname = "";
            float newprice = 0;

            Product[] products = new Product[5];
            Product newProduct = new Product(newcode, newname, newprice);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            StreamWriter sw = new StreamWriter("Products.json", false);

            string jsonString = "";
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Введите код продукта № {i}:");
                newcode = int.Parse(Console.ReadLine());
                Console.Write($"Введите имя продукта № {i}:");
                newname = (Console.ReadLine());
                Console.Write($"Введите цену продукта № {i}:");
                newprice = float.Parse(Console.ReadLine());

                newProduct = new Product(newcode, newname, newprice);
                products[i - 1] = newProduct;
            }

            jsonString = JsonSerializer.Serialize<Product[]>(products, options);

            sw.WriteLine(jsonString);
            sw.Close();

            Console.WriteLine(jsonString);

            Console.ReadKey();

        }
    }

}
