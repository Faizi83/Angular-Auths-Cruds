using System.ComponentModel.DataAnnotations;

namespace work.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Department { get; set; }

        public bool is_deleted { get; set; }
    }

 
}
