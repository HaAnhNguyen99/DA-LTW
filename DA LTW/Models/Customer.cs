using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_LTW.Models
{
    public class Customer
    {
        [Key]
        public int sdt { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email_Address { get; set; }


    }
}
