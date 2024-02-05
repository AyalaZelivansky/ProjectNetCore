using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Serilog;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConrtroleerToDo : ControllerBase
    {
        private readonly IToDo _ToDo;
        public ConrtroleerToDo(IToDo ToDo)
        {
            _ToDo = ToDo;
        }

       

        [HttpGet]
        [Route("/ToDoGet")]

        public async Task<ActionResult<List<ToDo>>> Get()
        {
            List<ToDo> res = await _ToDo.GetAllToDo();
            Log.Information("getToDo");
            return Ok(res);
        }



 
     
        [HttpPost]
        [Route("/ToDoPost")]
        public async Task<ActionResult> PostToDo([FromBody] ToDo t)
        {
            await _ToDo.AddToDo(t);
            Log.Information("PostToDo");

            return Ok();
        }

        [HttpPut]
        [Route("/ToPut{id}")]

        public async Task<ActionResult> PutToDo(int id, [FromBody] ToDo t)
        {
            await _ToDo.UpdateToDo(id, t);
            Log.Information("PutToDo");

            return Ok();
        }



        [HttpDelete]
        [Route("/ToDelete{id}")]


        public async Task<ActionResult> DeleteToDo(int id)
        {
            await _ToDo.DeleteToDo(id);
            Log.Information("DeleteToDo");

            return Ok();
        }
    }




}

