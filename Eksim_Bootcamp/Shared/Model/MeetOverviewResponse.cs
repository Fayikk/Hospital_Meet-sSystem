using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksim_Bootcamp.Shared.Model
{
    public class MeetOverviewResponse
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; } //controller
        public DateTime CreatedMeet { get; set; } //service
        public string DoctorName { get; set; } //
        public string PolyclinicName { get; set; }  //
        public DateTime MeetDate { get; set; }  //
        public bool Status { get; set; }
    }
}
