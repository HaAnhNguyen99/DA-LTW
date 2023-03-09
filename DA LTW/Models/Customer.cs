using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_LTW.Models
{
    public class Customer
    {
        // khoa chinh sdt
        [Key]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public int sdt { get; set; }

        // ten day du
        [Required]
        public string Fullname { get; set; }

        // dia chi email
        [Required]
        public string Email_Address { get; set; }

    }
}
