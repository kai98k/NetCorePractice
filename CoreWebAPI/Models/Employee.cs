using System;
using System.Collections.Generic;

namespace CoreWebAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TodoListInsertEmployees = new HashSet<TodoList>();
            TodoListUpdateEmployees = new HashSet<TodoList>();
        }

        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid JobTitleId { get; set; }
        public Guid DivisionId { get; set; }

        public virtual Division Division { get; set; } = null!;
        public virtual JobTitle JobTitle { get; set; } = null!;
        public virtual ICollection<TodoList> TodoListInsertEmployees { get; set; }
        public virtual ICollection<TodoList> TodoListUpdateEmployees { get; set; }
    }
}
