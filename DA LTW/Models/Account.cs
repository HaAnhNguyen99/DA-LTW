using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DA_LTW.Models
{
    public class Account
    {
        // khoa chinh
        [Key]    
        public int IdAccount { get; set; }

        // khoa ngoai sdt table customer
        [ForeignKey("Customer")]
        public int sdt { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        // mat khau
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        

    }
}
