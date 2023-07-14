using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        [Column("PostID")]
        public int PostId { get; set; }
        [Required]
        [Column("Post_Type")]
        [StringLength(1)]
        public string PostType { get; set; }
        [Column("Posted_On")]
        public int PostedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime PostedAt { get; set; }
        public int PostedBy { get; set; }
        [Required]
        [Column("Post description", TypeName = "text")]
        public string PostDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }

        [ForeignKey(nameof(PostedBy))]
        [InverseProperty(nameof(UserProfile.Posts))]
        public virtual UserProfile PostedByNavigation { get; set; }
        [ForeignKey(nameof(PostedOn))]
        [InverseProperty(nameof(Group.Posts))]
        public virtual Group PostedOnNavigation { get; set; }
        [InverseProperty(nameof(Comment.Post))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
