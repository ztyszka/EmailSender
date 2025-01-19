import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MailCampaignService } from '../../services/mail-campaign.service';

@Component({
  selector: 'app-new-email-campaign',
  standalone: false,
  
  templateUrl: './new-email-campaign.component.html',
  styleUrls: ['./new-email-campaign.component.css', '../../app.component.scss']
})
export class NewEmailCampaignComponent {
  constructor(private mailCampaignService: MailCampaignService, 
              private formBuilder: FormBuilder){
  }
  formValid: boolean = true;
  newCampaignForm: any;

  ngOnInit(){
    this.newCampaignForm = this.formBuilder.group({
      groupId: [0, Validators.required],
      subject:['', Validators.required],
      message: ['', Validators.required]
    })
  }

  onSubmit(){
    if(this.newCampaignForm.valid){
      this.mailCampaignService.postEmailCampaign(this.newCampaignForm.value).subscribe(() => {
        console.log("campaign sent")
        // add success toaster
      });
      console.log(this.newCampaignForm.value)
    } else{
      this.formValid = false;
    }
  }
}
