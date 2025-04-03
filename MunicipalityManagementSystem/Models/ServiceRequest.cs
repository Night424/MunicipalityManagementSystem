using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestID { get; set; }
        
        public int CitizenID { get; set; }
        
        [Required]
        public string ServiceType { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        
        public string Status { get; set; } = "Pending";
        
        [ForeignKey("CitizenID")]
        public Citizen Citizen { get; set; }
    }
}
