using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class GroupRequestViewModel
    {

        public int SentTo { get; set; }
        public int GroupId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsApproved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
