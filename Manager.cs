using System.ComponentModel.DataAnnotations;

namespace online_internet_banking.Models
{
    public class Manager
    {
        [Key]
       
        [Required]
        public int BMID { get; set; }
        [Required]
        public string password { get; set; }
        public int branchcode { get; set; }
        public string branchcity {get; set; }
    }
}
