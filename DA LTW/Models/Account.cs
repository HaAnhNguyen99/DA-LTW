using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DA_LTW.Models
{
    public class Account
    {
        // Foreign key to account
        [Key]
        [ForeignKey("Customer")]
        public int sdt { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        [Required]
        public string password { get; set; }
    }
}
