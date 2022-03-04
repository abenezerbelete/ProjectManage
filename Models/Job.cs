#nullable disable
using System.ComponentModel.DataAnnotations;
using ProjectManage.Data;

namespace ProjectManage.Models
{
    public class Job
    {   
        public int Id { get; set; } 

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}