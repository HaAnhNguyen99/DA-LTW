using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_LTW.Models
{
    [Keyless]
    public class UserRole
    {
        // khoa ngoai account
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
        [Required]
        public virtual Account Account { get; set; }

        // khoa ngoai roles
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
