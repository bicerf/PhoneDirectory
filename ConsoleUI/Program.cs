using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager(new EfPersonDal());
            foreach (var person in personManager.GetAll())
            {
                Console.WriteLine(person.FirstName+" "+person.LastName);
            }
            foreach (var person in personManager.GetAllByFirstName("Ayşe"))
            {
                Console.WriteLine(person.LastName+" "+person.PhoneNumber);
            }
        }
    }
}
