import {Component, NgModule, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {CreateServerDialogComponent} from "../../../servers/components/create-server-dialog/create-server-dialog.component";
import {MatIconModule} from "@angular/material/icon";

@Component({
  selector: 'app-channels-sidebar',
  templateUrl: './channels-sidebar.component.html',
  styleUrls: ['./channels-sidebar.component.scss']
})
export class ChannelsSidebarComponent implements OnInit {

  constructor(private _dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  openCreateServerDialog(): void {
    const dialogRef = this._dialog.open(CreateServerDialogComponent,
      {
        width: '50%'
      });
  }
}

@NgModule({
  exports: [
    ChannelsSidebarComponent
  ],
  imports: [
    MatIconModule
  ],
  declarations: [ChannelsSidebarComponent]
})
export class ChannelsSidebarModule {}
