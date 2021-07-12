using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : IPersonDal
    {
        public void Add(Person entity)
        {
            using (PhoneDirectoryContext context=new PhoneDirectoryContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Person entity)
        {
            using (PhoneDirectoryContext context = new PhoneDirectoryContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Person Get(Expression<Func<Person, bool>> filter)
        {
            using (PhoneDirectoryContext context=new PhoneDirectoryContext())
            {
                return context.Set<Person>().SingleOrDefault(filter);
            }
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            using (PhoneDirectoryContext context=new PhoneDirectoryContext())
            {
                return filter == null
                    ? context.Set<Person>().ToList()   //filtre null ise
                    : context.Set<Person>().Where(filter).ToList();

            }
        }

        public void Update(Person entity)
        {
            using (PhoneDirectoryContext context = new PhoneDirectoryContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
