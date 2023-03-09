using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksim_Bootcamp.Shared.DTO
{
    public class MeetDTO
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; } 
        public DateTime MeetDate { get; set; }
        //public bool Status { get; set; }

    }
}
