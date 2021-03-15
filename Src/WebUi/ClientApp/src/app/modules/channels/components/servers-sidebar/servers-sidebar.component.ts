import {Component, NgModule, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {CreateServerDialogComponent} from "../../../servers/components/create-server-dialog/create-server-dialog.component";
import {MatIconModule} from "@angular/material/icon";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";

@Component({
  selector: 'app-channels-sidebar',
  templateUrl: './servers-sidebar.component.html',
  styleUrls: ['./servers-sidebar.component.scss']
})
export class ServersSidebarComponent implements OnInit {
  private _connection: HubConnection;

  constructor(private _dialog: MatDialog) {
  }

  ngOnInit(): void {
    // this._connection = new HubConnectionBuilder()
    //   .withUrl('/hubs/server', )
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
    ServersSidebarComponent
  ],
  imports: [
    MatIconModule
  ],
  declarations: [ServersSidebarComponent]
})
export class ServersSidebarModule {}
