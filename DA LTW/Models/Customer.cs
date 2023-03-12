using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_LTW.Models
{
    public class Customer
    {
        // khoa chinh sdt
        [StringLength(10, ErrorMessage = "Chiều dài SDT phải là 10 số")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string sdt { get; set; }

        // ten day du
        [Required(ErrorMessage = "Vui lòng nhập họ tên đầy đủ")]
        public string Fullname { get; set; }

        // dia chi email
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email_Address { get; set; }
    }
}
