using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models.Meetings
{
    public class Meetings
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Agenda { get; set; }

        public string MeetingTime { get; set; }
         
        [JsonIgnore]
        public virtual ICollection<AttendiesMeetings> AttendiesMeetings { get; set; }

    }

}

