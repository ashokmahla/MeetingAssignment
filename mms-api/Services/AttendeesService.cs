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
    }
}
