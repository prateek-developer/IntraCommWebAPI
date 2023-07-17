using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class UserProfile
    {
        [Required]
        [Column("First_Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Contact { get; set; }
        [Column("DOB", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string State { get; set; }
        [Required]
        [StringLength(30)]
        public string PermanentCity { get; set; }
        [Required]
        [StringLength(30)]
        public string PermanentState { get; set; }

    }
}
