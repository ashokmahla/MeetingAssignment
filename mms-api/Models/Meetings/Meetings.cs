using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Meetings
{
    public class Meetings
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string AttendeesId { get; set; }

        public string Agenda { get; set; }

        public string MeetingTime { get; set; }
    }

}

