using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{

    public interface IEmployee
    {
        int ID { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime DateOfBirth { get; set; }
    }
    public class Employee: IEmployee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
