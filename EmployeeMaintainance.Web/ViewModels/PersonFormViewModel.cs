﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMaintainance.Web.ViewModels
{
    public class PersonFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
