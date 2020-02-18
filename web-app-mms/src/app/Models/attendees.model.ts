export class Attendees {
    id: string;
    name: string;
    constructor()
    constructor(attendees: Attendees)
    constructor(attendees?: any) {
        this.id = attendees && attendees.id || '';
        this.name = attendees && attendees.name || '';
    }
 }


 export class MappedAttendees{
    count:number;
    name: string;
    constructor();
    constructor(attendees: MappedAttendees);
    constructor(attendees?: any) {
        this.count = attendees && attendees.count || 0;
        this.name = attendees && attendees.name || '';
    }

 }