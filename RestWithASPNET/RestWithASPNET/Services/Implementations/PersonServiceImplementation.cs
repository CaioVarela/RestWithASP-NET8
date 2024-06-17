using Microsoft.AspNetCore.Http.HttpResults;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person? FindById(long id)
        {
            var query = _context.People.SingleOrDefault((p => p.Id.Equals(id)));
            if (query != null)
                return query;
            return null;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if(!Exists(person.Id))
                return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id == person.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long Id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id == Id);

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id.Equals(id));
        }
    }
}
