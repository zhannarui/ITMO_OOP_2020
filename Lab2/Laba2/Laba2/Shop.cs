using System;
using System.Collections.Generic;

namespace Laba2
{
    public class Shop
    {
        private string ShopUid;
        private string ShopName;
        private string ShopAddress;
        private Dictionary<string, Stock> ProductList = new Dictionary<string, Stock>();
        public Shop(string name, string address)
        {
            this.ShopName = name;
            this.ShopAddress = address;            
            this.ShopUid = Guid.NewGuid().ToString();
        }
        public string GetShopUid() { return this.ShopUid; }
        public string GetName() { return this.ShopName; }
        public string GetAddress() { return this.ShopAddress; }
        public void AddToDictionary(Products products, int cost, int count)
        {
            if(ProductList.ContainsKey(products.GetProductUid()))
            {
                ProductList[products.GetProductUid()].SetCost(cost);
                ProductList[products.GetProductUid()].SetCount(ProductList[products.GetProductUid()].GetCount() + count);
            }
            else
            {
                ProductList.Add(products.GetProductUid(),new Stock(products.GetName(), cost, count));
            }
        }
        public void BuyOnCash(int cash)
        {
            foreach (var i in ProductList)
            {
                int currentCount;
                if ((currentCount = cash / i.Value.GetCost()) > 0)
                {
                    Console.WriteLine("Вы можете купить " + currentCount + " шт продукта " + i.Value.GetName());
                }
                else
                {
                    Console.WriteLine("Не удалось совершить покупку так как не хватает денег");
                }
            }
        }
        public int ConsigmentOfProducts(List<KeyValuePair<Products,int>>list)
        {
            int result = 0;
            foreach (var i in list)
            {
                var prod = i.Key;
                var count = i.Value;
                if (ProductList[prod.GetProductUid()].GetCount() - count >= 0)
                {
                    result += ProductList[prod.GetProductUid()].GetCost() * count;
                    ProductList[prod.GetProductUid()].SetCount(ProductList[prod.GetProductUid()].GetCount() - count);
                }
                else
                {
                    throw new Exception("Не хватает товара");
                }
            }
            return result;
        }
        public Dictionary<string, Stock> GetProductsList()
        {
            return ProductList;
        }
    }
}