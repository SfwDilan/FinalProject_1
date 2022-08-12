using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //SOLİD'in Open Closed Prensibini uyguladık-Mevcuttaki kodlar değişmedi. 
            //Sadece EfProductDal eklendi. Yani mimari değişti.(Yani entity framework mimarisi kullanıldı.)
           
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(10,1000))  //Fiyatı min:10 max:1000 olan ürünleri getir.
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
