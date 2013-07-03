using Performance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance.Controllers
{
    public class ValuesController : ApiController
    {
        AddressBook book;

        public ValuesController()
        {
            book = new AddressBook();
        }

        // GET api/values

        //Test with e.g.
        //http://localhost:.../api/values?$top=8

        [Queryable(PageSize = 5)]
        public IQueryable<PersonDTO> Get()
        {
            return book.Persons.AsEnumerable().Select(m => new PersonDTO(m)).AsQueryable();
        }

        // GET api/values/5

        //Test with e.g.
        //http://localhost:.../api/values/9

        public PersonDTO Get(Int32 id)
        {
            return new PersonDTO( book.Persons.Find(id) );
        }

        // POST api/values

        //Test with e.g.
        //$.ajax("http://localhost:.../api/values", { type : 'POST', data : { firstName : 'Florian', lastName : 'Rappl' } })

        public void Post([FromBody]PersonDTO person)
        {
            var p = new Person();
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            book.Persons.Add(p);
            book.SaveChanges();
        }

        // PUT api/values/5

        //Test with e.g.
        //$.ajax("http://localhost:.../api/values/9", { type : 'PUT', data : { firstName : 'Florian', lastName : 'Könner' } })

        public void Put(Int32 id, [FromBody]PersonDTO person)
        {
            Person p = book.Persons.Find(id);

            if (p != null)
            {
                p.FirstName = person.FirstName;
                p.LastName = person.LastName;
                book.SaveChanges();
            }
        }

        // DELETE api/values/5

        //Test with e.g.
        //$.ajax("http://localhost:.../api/values/11", { type : 'DELETE' })

        public void Delete(Int32 id)
        {
            Person p = book.Persons.Find(id);

            if (p != null)
            {
                book.Persons.Remove(p);
                book.SaveChanges();
            }
        }
    }
}