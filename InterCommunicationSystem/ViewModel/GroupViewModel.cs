using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class GroupViewModel
    {

        [Required]
        [Column("Group_Name")]
        [StringLength(50)]
        public string GroupName { get; set; }
        [Required]
        [Column("Group_Description", TypeName = "text")]
        public string GroupDescription { get; set; }
        [Column("Group_Type")]
        public int GroupType { get; set; }
        [Column("Created_At", TypeName = "date")]
        public DateTime CreatedAt { get; set; }
        [Column("Created_By")]
        public int CreatedBy { get; set; }

    }
}
