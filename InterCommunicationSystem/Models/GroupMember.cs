using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    [Keyless]
    [Table("Group_Members")]
    public partial class GroupMember
    {
        [Column("MemberID")]
        public int MemberId { get; set; }
        [Column("GroupID")]
        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(MemberId))]
        public virtual UserProfile Member { get; set; }
    }
}
