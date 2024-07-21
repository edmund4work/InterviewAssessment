using InterviewTestAPISleekFlow.Models.ViewModels;
using static InterviewTestAPISleekFlow.Models.ViewModels.todoVM;

namespace InterviewTestAPISleekFlow.Interfaces
{
    public interface ITodoService
    {
        commonJsonReturn GetAllTodos(todoDataRequest_Filter data);
        commonJsonReturn todoCRUD(todoDataRequest data);
    }
}

