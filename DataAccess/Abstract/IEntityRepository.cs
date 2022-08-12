using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //class: gelen deger sadece referans tip olsun anlamında. 
    //IEntity: sadece IEntity ve onu implemente eden nesneler  gelsin diyorum. 
    // class,IEntity : hem class hem IEntity olmalı.
    // new(): new'lenebilir olmalı- Bunu yazmamızın sebebi IEntity'i implemente eden nesne olsun ama IEntity olmasın.
    // IEntity new'lenmediği için doğal olarak new() yazmamız onu devre dışı bıraktı.
    public interface IEntityRepository<T> where T:class,IEntity,new()    
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //Expression : p=>p.CategoryId==2....
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
