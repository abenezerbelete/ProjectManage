using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ProjectManage.Models;

namespace ProjectManage.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? LastName { get; set; }
        public IList<UserProject>? AssignedProject { get; set; }
    }
}