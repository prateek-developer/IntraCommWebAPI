using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.ViewModel
{
    public class PostViewModel
    {


        public string PostType { get; set; }
    
        public int PostedOn { get; set; }
      
        public DateTime PostedAt { get; set; }
        public int PostedBy { get; set; }
       
        public string PostDescription { get; set; }
    
        public DateTime? StartTime { get; set; }
    
        public DateTime? EndTime { get; set; }

    }
}
