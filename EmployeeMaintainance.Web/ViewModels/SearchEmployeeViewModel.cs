using System.ComponentModel.DataAnnotations;

namespace EmployeeMaintainance.Web.ViewModels
{
    public class SearchEmployeeViewModel
    {
        public string Term { get; set; }
        public int Id { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }


    }
}
