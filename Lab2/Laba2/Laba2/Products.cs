using System;
namespace Laba2
{
    public class Products
    {
        private string ProductUid;
            private string ProductName;

            public Products(string name)
            {
                this.ProductName = name;
                this.ProductUid = Guid.NewGuid().ToString();
            }
            public string GetProductUid()
            {
                return this.ProductUid;
            }

            public string GetName()
            {
                return this.ProductName;
            }
    }
}