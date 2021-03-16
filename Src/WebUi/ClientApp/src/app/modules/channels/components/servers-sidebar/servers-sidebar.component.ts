import {Component, NgModule, OnInit} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {CreateServerDialogComponent} from "../../../servers/components/create-server-dialog/create-server-dialog.component";
import {MatIconModule} from "@angular/material/icon";
import {HubConnection} from "@microsoft/signalr";
import {HubBuilderService} from "../../../../core/hubs/hub-builder.service";
import {NGXLogger} from "ngx-logger";
import {Server} from "../../../../core/models/servers/server-model";
import {ServersService} from "../../../../core/services/servers/servers.service";
import {CommonModule} from "@angular/common";
import {MatTooltipModule} from "@angular/material/tooltip";
import {JoinedServerResponse} from "../../../../core/models/hubs/responses/joined-server-response.model";

@Component({
  selector: 'app-channels-sidebar',
  templateUrl: './servers-sidebar.component.html',
  styleUrls: ['./servers-sidebar.component.scss']
})
export class ServersSidebarComponent implements OnInit {
  private _connection: HubConnection;
  public servers: Server[];

  constructor(private _dialog: MatDialog,
              private _hubBuilder: HubBuilderService,
              private _logger: NGXLogger,
              private _serversService: ServersService) {
  }

  async ngOnInit(): Promise<void> {
    this._connection = await this._hubBuilder.build("/hubs/server");

    await this._connection.start();
    this._logger.info('Connecting to the server hub.');

    this._connection.on('JoinedServer', (n: JoinedServerResponse) => {
      this._logger.info('Joined Server!', n);
      this.getServer(n.serverId);
    });

    this._serversService.getServers()
      .subscribe(s => this.servers = s);
  }

  getServer(id: string): void {
    this._serversService.getServer(id)
      .subscribe(s => {
        this.servers.unshift(s);
      });
  }

  openCreateServerDialog(): void {
    this._dialog.open(CreateServerDialogComponent,
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
    MatIconModule,
    CommonModule,
    MatTooltipModule
  ],
  declarations: [ServersSidebarComponent]
})
export class ServersSidebarModule {
}
