using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.ViewModels
{
    public class DashboardViewModel
    {
        public int CitizenCount { get; set; }
        public int ServiceRequestCount { get; set; }
        public int StaffCount { get; set; }
        public int ReportCount { get; set; }
        public List<ServiceRequest> RecentServiceRequests { get; set; }
    }
}