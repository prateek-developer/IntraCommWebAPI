using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterCommunicationSystem.Models
{
    public partial class Event
    {
        [Key]
        [Column("EventID")]
        public int EventId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string EventsDescription { get; set; }
        [Column("PostID")]
        public int PostId { get; set; }
        [Required]
        [Column("URl")]
        [StringLength(100)]
        public string Url { get; set; }

        [ForeignKey(nameof(PostId))]
        [InverseProperty("Events")]
        public virtual Post Post { get; set; }
    }
}
