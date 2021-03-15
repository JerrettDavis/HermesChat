import {Component, NgModule, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {CreateServerDialogComponent} from "../../../servers/components/create-server-dialog/create-server-dialog.component";
import {MatIconModule} from "@angular/material/icon";
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {HubBuilderService} from "../../../../core/hubs/hub-builder.service";
import {NGXLogger} from "ngx-logger";

@Component({
  selector: 'app-channels-sidebar',
  templateUrl: './servers-sidebar.component.html',
  styleUrls: ['./servers-sidebar.component.scss']
})
export class ServersSidebarComponent implements OnInit {
  private _connection: HubConnection;

  constructor(private _dialog: MatDialog,
              private _hubBuilder: HubBuilderService,
              private _logger: NGXLogger) {
  }

  async ngOnInit(): Promise<void> {
    this._connection = await this._hubBuilder.build("/hubs/server");

    await this._connection.start();
    this._logger.info('Connecting to the server hub.');

    this._connection.on('JoinedServer', (n) => {
      this._logger.info('Joined Server!', n);
    });
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
