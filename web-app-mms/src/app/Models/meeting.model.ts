export class Meeting {
    id: number;
    subject: string;
    attendeesId: string;
    agenda: string;
    meetingTime: string;

    constructor()
    constructor(meeting: Meeting)
    constructor(meeting?: any) {
        this.id = meeting && meeting.id || 0;
        this.subject = meeting && meeting.subject || '';
        this.attendeesId = meeting && meeting.attendeesId || '';
        this.agenda = meeting && meeting.agenda || '';
        this.meetingTime = meeting && meeting.meetingTime || '';
    }
 }