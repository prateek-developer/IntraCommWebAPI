using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class LoginViewModel
    {


        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
       
        [Required]

        [StringLength(256)]
        public string Password { get; set; }

       
    }
}
