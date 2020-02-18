using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models.Meetings;

namespace WebApi.Services
{

    public interface IAttendeesService
    {
        IEnumerable<Attendees> GetAll();
        IEnumerable<MappedAttendees> GetMappedAttendies();

    }
    public class AttendeesService : IAttendeesService
    {
        private DataContext _context;

        public AttendeesService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendees> GetAll()
        {
            return _context.Attendees;
        }

        public IEnumerable<MappedAttendees> GetMappedAttendies()
        {
           var attendies  = _context.Attendees;
            var meetings = _context.Meetings;

            List<int> ids = new List<int>();
            foreach (var item in meetings)
            {
                 var numbers = item.AttendeesId
                    .Split(',')
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .ToList();
                ids.AddRange(numbers);
            }

            var allGroupedIds = ids.GroupBy(x => x).Select(x => new { key = x.Key, val = x.Count() });

            List<MappedAttendees> list = new List<MappedAttendees>();
            foreach (var item in attendies)
            {
                var entity = new MappedAttendees();
                entity.Name = item.Name;
                entity.Count = allGroupedIds.Where(s => s.key == item.Id).Select(x => x.val).FirstOrDefault();
                list.Add(entity);
            }

            return list;
        }
    }
}
