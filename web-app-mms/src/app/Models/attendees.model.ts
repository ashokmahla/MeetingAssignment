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
