using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using webapiAPP.Model;

namespace webapiAPP.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TestRepo _repository;

        public TodoController(TestRepo repository)
        {
            _repository = repository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _repository.AllItems;
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Todo item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _repository.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

     
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.TryDelete(id))
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
