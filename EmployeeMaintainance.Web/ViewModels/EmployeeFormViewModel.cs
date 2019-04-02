using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using EmployeeMaintainance.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace EmployeeMaintainance.Web.ViewModels
{
    public class EmployeeFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public PersonFormViewModel PersonalDetails { get; set; }

    }
}
