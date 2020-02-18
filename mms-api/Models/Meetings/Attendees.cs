using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Meetings
{
    public class Attendees
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MappedAttendees 
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
