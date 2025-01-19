import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { Group } from '../models/group.model';


@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private baseUrl = 'http://localhost:5086/Contacts';

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]>{
    return this.http.get<Contact[]>(`${this.baseUrl}`);
  }

  getContactDetails(id: number): Observable<Group[]>{
    return this.http.get<Group[]>(`${this.baseUrl}/${id}`)
  }

  deleteContact(id: number){
    const path = `${this.baseUrl}/${id}/delete`;
    return this.http.delete(path);
  }
}
