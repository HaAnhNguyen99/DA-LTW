using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_LTW.Models
{
    [PrimaryKey(nameof(IdAccount), nameof(IdRoles))]
    public class UserRole
    {
        // khoa ngoai account
        [ ForeignKey("Account")]
        public int IdAccount { get; set; }

        // khoa ngoai roles
        [ ForeignKey("Roles")]
        public int IdRoles { get; set; }

        public virtual Account Account { get; set; }
        public virtual Roles Roles { get; set; }

    }
}
