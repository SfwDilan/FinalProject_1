using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using blogu içerisine yazılan nesneler anında garbage collectore gelir ve silinir iş bitince.
            //using kulanmasan da olur ama using le daha performanslı iş yapmmış olursun.
            //using: IDisposable pattern implemantasyonudur.

            using (NorthwindContext northwindContext=new NorthwindContext()) 
            {
                var addedEntity = northwindContext.Entry(entity); 
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())
            {
                var deletedEntity = northwindContext.Entry(entity); // Referans adersini yakala.
                deletedEntity.State = EntityState.Deleted;          // Durumunu belirt(ekleme-silme-güncelleme)
                northwindContext.SaveChanges();
            }
        }
        //Bu kodları category, customer ve diğer veritabanı nesneleri için de yapmamız gerekicek.
        //İşte bu gibi stardartlaşan kodlar gördüğümüz an GENERİC yapmamız gerek ...
        //FinalProject2 projemizde bu update yapılacak.
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())
            {
                return northwindContext.Set<Product>().SingleOrDefault(filter);  // tek data getirir.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())    
            {
                // ternary operator 
                return filter == null
                    ? northwindContext.Set<Product>().ToList()
                    : northwindContext.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())
            {
                var updatedEntity = northwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }
    }
}
