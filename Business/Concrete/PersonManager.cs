using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;

        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public List<Person> GetAllByFirstName(string firstName)
        {
            return _personDal.GetAll(p => p.FirstName == firstName);
        }
    }
}
