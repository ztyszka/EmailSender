import { Contact } from "./contact.model";
import { Group } from "./group.model";

export class ContactListItem{
    public contact: Contact = new Contact();
    public groups: Group[] = [];
    public isExpanded: boolean = false;
}