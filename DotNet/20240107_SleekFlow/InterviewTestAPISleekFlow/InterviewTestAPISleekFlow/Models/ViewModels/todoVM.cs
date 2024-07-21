using System;
namespace InterviewTestAPISleekFlow.Models.ViewModels
{
	public class todoVM
	{
		public class todoDataRequest
		{
            public string action { get; set; }
            public tblTodo todoData { get; set; }
        }
        public class todoDataRequest_Filter
        {
            public List<int>? statusIDSelected { get; set; }
            public DateTime? dueDateFrom { get; set; }
            public DateTime? dueDateTo { get; set; }
        }
        public class todoDataReturn : tblTodo
        {
            public string statusName { get; set; }
            public string priorityName { get; set; }
        }
    }
}

