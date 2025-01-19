import { Component } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { ContactListItem } from '../../models/contact-list-item.model';
import { NewContactPopupService } from '../../services/popup/new-contact-popup.service';

@Component({
  selector: 'app-contacts',
  standalone: false,
  
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css', '../../app.component.scss'],
})
export class ContactsComponent {
  contacts: ContactListItem[] = [];

  constructor(private contactService: ContactService, private newContactPopupService: NewContactPopupService){}

  ngOnInit(): void {
    this.refreshList();
  }

  getDetails(contact: ContactListItem){
    contact.isExpanded = !contact.isExpanded;
    if(contact.groups.length == 0){
      this.contactService.getContactDetails(contact.contact.id).subscribe((details) => {
        contact.groups = details;
      })
    }
    console.log(contact.groups);
  }

  delete(contactId: number) {
    this.contactService.deleteContact(contactId).subscribe(() => console.log("delete succesful"));
    this.contacts = this.contacts.filter(contact => contact.contact.id != contactId);
  }

  refreshList(){
    this.contactService.getContacts().subscribe((contacts) => {
      this.contacts = contacts.map(c => {return {contact: c, groups: [], isExpanded: false};}) as ContactListItem[];
    })
  }

  openNewContactPopup() {
    this.newContactPopupService.openPopup();
    }
}
