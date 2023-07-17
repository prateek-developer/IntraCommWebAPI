using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class GroupRequestViewModel
    {

        [Column("Sent_to")]
        public int SentTo { get; set; }
        [Column("GroupID")]
        public int GroupId { get; set; }
        [Column("isAccepted")]
        public bool IsAccepted { get; set; }
        [Column("isApproved")]
        public bool IsApproved { get; set; }
        [Column("Created_by")]
        public int CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }


    }
}
