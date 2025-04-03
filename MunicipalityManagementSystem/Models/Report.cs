using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        
        public int CitizenID { get; set; }
        
        [Required]
        public string ReportType { get; set; }
        
        [Required]
        public string Details { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        
        public string Status { get; set; } = "Under Review";
        
        [ForeignKey("CitizenID")]
        public Citizen Citizen { get; set; }
    }
}
