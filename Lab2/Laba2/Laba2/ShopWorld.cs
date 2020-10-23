using System;
using System.Collections.Generic;

namespace Laba2
{
    public class ShopWorld
    {
        private List<Shop> list = new List<Shop>();
        public Shop MakeMarket(string name, string address)
        {
            var Shop = new Shop(name, address);
            list.Add(Shop);
            return Shop;
        }
        public void CheapestOne(string product)
        {
            var listProd = new List<string>();
            int minPrice = -1;
            string shopWithMinPrice = "";
            for (int i = 0; i < list.Count; i++) 
            {
                Dictionary<string, Stock> productList = list[i].GetProductsList();
                foreach (var item in productList) 
                {

                    if (!item.Value.GetName().Equals(product))
                    {
                        continue;
                    }
                    else
                    {
                        int price = item.Value.GetCost();
                        if (minPrice == -1)
                        {
                            minPrice = price;
                            shopWithMinPrice = list[i].GetName();
                            listProd.Add(shopWithMinPrice);
                        }
                        else
                        {
                            if (price < minPrice)
                            {
                                minPrice = price;
                                shopWithMinPrice = list[i].GetName();
                                listProd.Clear();
                                listProd.Add(shopWithMinPrice);

                            }
                            else if (price == minPrice)
                            {
                                listProd.Add(list[i].GetName());
                            }
                        }

                    }

                }

            }

            if (minPrice == -1 || shopWithMinPrice == "")
            {
                throw new Exception("В данном магазине нет нужных продуктов");
            }
            for (int i = 0; i < listProd.Count; i++)
            {
                Console.WriteLine(listProd[i] + ":" + minPrice + " рублей");
            }
        }
        public void CheapestConsigment(Dictionary<Products, int> banchOfProd)
        {
            int minSum = -1;
            string shopWithMinPrice = "";
            for (int i = 0; i < list.Count; i++) 
            {
                Dictionary<string, Stock> productList = list[i].GetProductsList();
                int size = banchOfProd.Count;
                int sum = 0;
                foreach (var item in productList) 
                {
                    if (productList.Count < banchOfProd.Count) 
                        break;
                    foreach (var prods in banchOfProd) 
                    {

                        if (prods.Key.GetName().Equals(item.Value.GetName())) {

                            if (item.Value.GetCount() >= prods.Value) 
                            {
                                size--;
                            }
                        }
                    }
                }
                if (size != 0)
                    continue;
                else
                {
                    foreach (var prods in banchOfProd)
                    {
                        foreach (var item in productList)
                        {

                            if (prods.Key.GetName().Equals(item.Value.GetName())) { 

                                sum += prods.Value * item.Value.GetCost();

                            }
                        }
                    }
                    if (minSum == -1)
                    {
                        minSum = sum;
                        shopWithMinPrice = list[i].GetName();
                    }
                    else
                    {
                        if (sum < minSum)
                        {
                            minSum = sum;
                            shopWithMinPrice = list[i].GetName();
                        }
                    }

                }
            }

            if (shopWithMinPrice.Equals(""))
                Console.WriteLine("Нет магазина с такой партией товаров");
            else
                Console.WriteLine(shopWithMinPrice + " " + minSum); 

        }
    }
}