using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftDeleted.EntityFramework;
using LearnSoftDeleted.EntityFramework.Entities;
using LearnSoftDeleted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnSoftDeleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private DBContext _context;
        public CategoriesController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult Post(CreateOrUpdateCategoryVM categoryVM)
        {
            var category = new Category();
            category.Code = categoryVM.Code;
            category.Name = categoryVM.Name;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, CreateOrUpdateCategoryVM categoryVM)
        {
            var category = _context.Categories.Where(x=>x.Id == id).FirstOrDefault();
            category.Code = categoryVM.Code;
            category.Name = categoryVM.Name;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
