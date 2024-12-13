using System.ComponentModel.DataAnnotations;

namespace work.Models
{
    public class Register
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }


    }
}
