using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithSwagger.Context;
using WebApiWithSwagger.Models;

namespace WebApiWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public StudentsController(DataBaseContext context)
        {
            _context = context;
        }
        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(int id)
        {
            return _context.Students.SingleOrDefault(x=>x.StudentId == id);
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            var update = _context.Students.Find(id);
            if(update != null)
            {
                _context.Students.Update(update);
                _context.SaveChanges();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var del = _context.Students.Find(id);
            if (del != null)
            {
                _context.Remove(del);
                _context.SaveChanges();
            }
           
        }
    }
}
