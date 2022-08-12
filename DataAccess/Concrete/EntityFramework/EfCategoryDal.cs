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
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var addedEntity = northwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deletedEntity = northwindContext.Entry(entity); 
                deletedEntity.State = EntityState.Deleted;          
                northwindContext.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())
            {
                return northwindContext.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (NorthwindContext northwindContext=new NorthwindContext())
            {
                return filter == null
                    ? northwindContext.Set<Category>().ToList()
                    : northwindContext.Set<Category>().Where(filter).ToList();
            }
        }

        public void Update(Category entity)
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
