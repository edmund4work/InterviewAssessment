using InterviewTestAPISleekFlow.Interfaces;
using InterviewTestAPISleekFlow.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static InterviewTestAPISleekFlow.Models.ViewModels.todoVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewTestAPISleekFlow.Controllers
{
    [ApiController]
    [Route("api/todo/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost, ActionName("getFullList")]
        public commonJsonReturn getTodoFullList (todoDataRequest_Filter data)
        {
            return _todoService.GetAllTodos(data);
        }


        [HttpPost, ActionName("crud")]
        public commonJsonReturn todoCRUD(todoDataRequest data)
        {
            return _todoService.todoCRUD(data);
        }
    }
}

