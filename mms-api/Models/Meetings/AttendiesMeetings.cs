using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Models.Meetings
{
    public class AttendiesMeetings
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        [JsonIgnore]
        public int MeetingId { get; set; }
        [JsonIgnore]
        public Meetings Meeting { get; set; }
    }
 
}
