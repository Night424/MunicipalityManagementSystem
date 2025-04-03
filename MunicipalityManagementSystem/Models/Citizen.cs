
using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Citizen
    {
        public int CitizenID { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
