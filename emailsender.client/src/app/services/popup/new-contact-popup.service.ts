import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewContactPopupComponent } from '../../components/new-contact-popup/new-contact-popup.component';

@Injectable({
  providedIn: 'root',
})
export class NewContactPopupService {
  constructor(private dialog: MatDialog) {}

  openPopup() {
    this.dialog.open(NewContactPopupComponent);
  }
}