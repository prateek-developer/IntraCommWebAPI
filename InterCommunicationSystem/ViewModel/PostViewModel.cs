using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class PostViewModel
    {


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

    }
}
