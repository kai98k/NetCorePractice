using CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly TodoContext _todoContext;
        //宣告 readonly db物件 _todoContext;

        public TodoListController(TodoContext todoContext)
        {
            //建構子注入
            _todoContext = todoContext;
        }


        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<TodoList> Get()
        {
            return _todoContext.TodoLists.ToList();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoList> Get(Guid id)
        {
            var result = _todoContext.TodoLists.Find(id);
            if (result == null)
            {
                return NotFound("無此筆資料");
            }
            return result;
        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult<TodoList> Post([FromBody] TodoList item)
        {
            _todoContext.TodoLists.Add(item);
            _todoContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = item.TodoId }, item); 
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
