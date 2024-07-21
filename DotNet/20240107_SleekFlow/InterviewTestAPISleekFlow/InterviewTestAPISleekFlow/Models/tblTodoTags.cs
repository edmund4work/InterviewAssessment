using System;
namespace InterviewTestAPISleekFlow.Models
{
	public class tblTodoTags
    {
        public int Id { get; set; }
        public int todoID { get; set; }
		public string tagName { get; set; }
        public bool enabled { get; set; }
	}
}
