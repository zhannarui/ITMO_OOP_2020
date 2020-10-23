using System;
using System.Collections.Generic;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            //задание 1
            ShopWorld w = new ShopWorld();
            Shop okay = w.MakeMarket("Окей", "улица Профессора Попова 6");
            Shop lenta = w.MakeMarket("Лента", "Вяземский переулок 25");
            Shop magnit = w.MakeMarket("Магнит", "Загребский бульвар 32");
            Console.WriteLine("Магазин: " + okay.GetName());
            Console.WriteLine(okay.GetAddress());
            Console.WriteLine(okay.GetShopUid());
            Console.WriteLine("Магазин: " + lenta.GetName());
            Console.WriteLine(lenta.GetAddress());
            Console.WriteLine(lenta.GetShopUid());
            Console.WriteLine("Магазин: " + magnit.GetName());
            Console.WriteLine(magnit.GetAddress());
            Console.WriteLine(magnit.GetShopUid());
            Console.WriteLine(" ");
            
            //задание 2
            Products mango = new Products("манго"); 
            Products bread = new Products("хлеб");
            Products juice = new Products("сок");
            Products pillow = new Products("подушка");
            Products cup = new Products("кружка");
            Products biscuit =new Products("печенье");
            Products watter =new Products("вода");
            Products apple =new Products("яблоко");
            Products avocado =new Products("авокадо");
            Products lemon =new Products("лимон");
            
            //задание 3
            okay.AddToDictionary(mango, 70, 10);
            okay.AddToDictionary(bread,67,4);
            okay.AddToDictionary(watter,19,14);
            okay.AddToDictionary(pillow,200,8);
            okay.AddToDictionary(cup,50,11);
            
            lenta.AddToDictionary(cup,100,6);
            lenta.AddToDictionary(pillow,150,11);
            lenta.AddToDictionary(avocado,88,15);
            lenta.AddToDictionary(biscuit,112,16);
            
            magnit.AddToDictionary(apple,52,6);
            magnit.AddToDictionary(juice,87,5);
            magnit.AddToDictionary(lemon,10,13);
            magnit.AddToDictionary(watter,16,12);
            magnit.AddToDictionary(mango,80,12);
            
            //задание 4
            Console.WriteLine("В этих магазинах выбранные вами товары самый дешевые: ");
            w.CheapestOne( "манго");
            w.CheapestOne("подушка");
            w.CheapestOne("вода");
            Console.WriteLine(" ");
            
            //задание 5
            Console.WriteLine("На данную сумму в магазине Окей:");
            okay.BuyOnCash(500);
            Console.WriteLine(" ");
            
            //задание 6
            Console.WriteLine("Стоимость вашей покупки в магазине Магнит:");
            var ProductList = new List<KeyValuePair<Products,int>>();
            ProductList.Add(new KeyValuePair<Products, int>(mango,5));
            ProductList.Add(new KeyValuePair<Products, int>(watter,4));
            ProductList.Add(new KeyValuePair<Products, int>(apple,2));
            Console.WriteLine(magnit.ConsigmentOfProducts(ProductList));
            Console.WriteLine(" ");
            
            //задание 7
            Console.WriteLine("В данном магазине партия выбранных вами товаров самая дешевая:");
            var banchList = new Dictionary<Products, int>(); 
            banchList.Add(pillow, 3);
            banchList.Add(biscuit, 2);
            banchList.Add(cup, 4);
            w.CheapestConsigment(banchList);


        }
    }
}