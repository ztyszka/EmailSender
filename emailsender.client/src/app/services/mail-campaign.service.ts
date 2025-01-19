import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmailCampaign } from '../models/email-campaign.model';


@Injectable({
  providedIn: 'root'
})
export class MailCampaignService {
  private baseUrl = 'http://localhost:5086/EmailCampaign';

  constructor(private http: HttpClient) { }

  postEmailCampaign(campaign: EmailCampaign){
    debugger
    return this.http.post<HttpClient>(`${this.baseUrl}`, campaign);
  }
}
