using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    [Keyless]
    public partial class Like
    {
        [Column("PostID")]
        public int PostId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserProfiles User { get; set; }
    }
}
