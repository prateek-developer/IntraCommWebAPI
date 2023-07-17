using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    [Table("Group_Invites_Requests")]
    public partial class GroupInvitesRequest
    {
        [Key]
        [Column("InviteID")]
        public int InviteId { get; set; }
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

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(UserProfiles.GroupInvitesRequestCreatedByNavigations))]
        public virtual UserProfiles CreatedByNavigation { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("GroupInvitesRequests")]
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(SentTo))]
        [InverseProperty(nameof(UserProfiles.GroupInvitesRequestSentToNavigations))]
        public virtual UserProfiles SentToNavigation { get; set; }
    }
}
