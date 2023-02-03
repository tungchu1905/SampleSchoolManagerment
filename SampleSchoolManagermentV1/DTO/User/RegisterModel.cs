﻿using System.ComponentModel.DataAnnotations;

namespace Authorization_RoleTest.Validation
{
    public class RegisterModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
