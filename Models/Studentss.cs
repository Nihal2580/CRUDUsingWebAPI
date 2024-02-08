using System.ComponentModel.DataAnnotations;

namespace CRUDUsingWebAPI.Models
{


    public class Studentss
    {
        public int id { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentGender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string stander { get; set; }
        [Required]
        public string fatherName { get; set; }
    }

}

