﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.ViewModel
{
    public class Credentials
    {

        [Required(ErrorMessage = "Поле є обов'язковим")]
        [EmailAddress(ErrorMessage = "Не валідна пошта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        public string Password { get; set; }
    }

    public class CustomRegisterModel
    {
        
        [Required(ErrorMessage = "Cant't be empty")]
        [EmailAddress(ErrorMessage = "Invalid email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Cant't be empty")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$", ErrorMessage = "Password must be at least 6 characters and contain digits, upper and lower case")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Cant't be empty")]
        //[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$", ErrorMessage = "Password must be at least 8 characters and contain digits, upper and lower case")]
        [Compare("Password", ErrorMessage = "Passwords do not matcht")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Cant't be empty")]
        public string ImageBase64 { get; set; }
        [Required(ErrorMessage = "Cant't be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Cant't be empty")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Cant't be empty")]
        public string LastName { get; set; }
      
        public DateTime DateOfBirth { get; set; }
    }

}
