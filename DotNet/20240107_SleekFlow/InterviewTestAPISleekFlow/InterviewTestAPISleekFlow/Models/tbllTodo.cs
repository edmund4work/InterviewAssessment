using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewTestAPISleekFlow.Models
{
    public class tblTodo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public bool enabled { get; set; }
        public required int statusID { get; set; } //from commonStatus.cs (1 : Active; 2 : Pending ; 3 : Discontinued ; 4 : Completed ; 5 Not Started)

        public int priority { get; set; } //1 : Urgent; 2 : Not Urgent ; 3 : Relax
        public int CreatedID { get; set; }
        public DateTime createdDate { get; set; }
        public int UpdatedID { get; set; }
        public DateTime updatedDate { get; set; }
    }

}

