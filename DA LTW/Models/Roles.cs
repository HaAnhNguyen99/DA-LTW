using System.ComponentModel.DataAnnotations;

namespace DA_LTW.Models
{
    public class Roles
    {
        [Key]
        public int IdRoles { get; set; }

        [Required(ErrorMessage ="Tên của vai trò không được để trống!")]
        public string NameRole { get; set; }


    }
}
