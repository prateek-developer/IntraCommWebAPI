using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    public partial class Comment
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Column("Commented_By")]
        public int CommentedBy { get; set; }
        [Column("PostID")]
        public int PostId { get; set; }
        [Required]
        [Column("Comment", TypeName = "text")]
        public string Comment1 { get; set; }
        [Column("Commented_At", TypeName = "datetime")]
        public DateTime CommentedAt { get; set; }

        [ForeignKey(nameof(CommentedBy))]
        [InverseProperty(nameof(UserProfile.Comments))]
        public virtual UserProfile CommentedByNavigation { get; set; }
        [ForeignKey(nameof(PostId))]
        [InverseProperty("Comments")]
        public virtual Post Post { get; set; }
    }
}
