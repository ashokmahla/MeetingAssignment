using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models.Meetings;

namespace WebApi.Services
{
    public interface IMeetingService
    {
        IEnumerable<Meetings> GetAll();
        Meetings GetById(int id);
        void Update(Meetings meeting);

        void Add(Meetings meeting);
    }

    public class MeetingService : IMeetingService
    {
        private DataContext _context;

        public MeetingService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Meetings> GetAll()
        {
            return _context.Meetings;
        }

        public Meetings GetById(int id)
        {
            return _context.Meetings.Find(id);
        }

        public void Update(Meetings meeting)
        {
            var databaseMeeting = _context.Meetings.Find(meeting.Id);

            if (databaseMeeting == null)
                throw new AppException("Meeting not found");

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(meeting.Subject))
                databaseMeeting.Subject = meeting.Subject;

            if (!string.IsNullOrWhiteSpace(meeting.Agenda))
                databaseMeeting.Agenda = meeting.Agenda;


            if (!string.IsNullOrWhiteSpace(meeting.AttendeesId))
                databaseMeeting.AttendeesId = meeting.AttendeesId;

            if (!string.IsNullOrWhiteSpace(meeting.MeetingTime))
                databaseMeeting.MeetingTime = meeting.MeetingTime;

            _context.Meetings.Update(databaseMeeting);
            _context.SaveChanges();
        }


        public void Add(Meetings meeting)
        {
            if (meeting == null)
                throw new AppException("Meeting not found");

            // update user properties if provided
            if (string.IsNullOrWhiteSpace(meeting.Subject))
                throw new AppException("Please fill subject");

            if (string.IsNullOrWhiteSpace(meeting.Agenda))
                throw new AppException("Please fill agenda");


            if (string.IsNullOrWhiteSpace(meeting.AttendeesId))
                throw new AppException("Please fill attendies");

            if (string.IsNullOrWhiteSpace(meeting.MeetingTime))
                throw new AppException("Please fill meeting date time");

            _context.Meetings.Update(meeting);
            _context.SaveChanges();
        }
    }
}
