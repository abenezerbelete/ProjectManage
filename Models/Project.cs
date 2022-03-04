#nullable disable
using System.ComponentModel.DataAnnotations;
using ProjectManage.Data;

namespace ProjectManage.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Technologies { get; set; }

        [Required]
        public string Client { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public IList<UserProject> AssignedUser { get; set; }
        public List<Job> Jobs { get; set; }
    }
}