import {Component, Input, NgModule, OnInit} from '@angular/core';
import {ServersService} from "@core/services/servers/servers.service";
import {Channel} from "@core/models/servers/channels/channel.model";
import {MatListModule} from "@angular/material/list";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-channel-list',
  templateUrl: './channel-list.component.html',
  styleUrls: ['./channel-list.component.scss']
})
export class ChannelListComponent implements OnInit {
  @Input() serverId: string;

  channels: Channel[] = [];
  constructor(private _serversService: ServersService) { }

  ngOnInit(): void {
    this._serversService.getChannels(this.serverId)
      .subscribe(c => this.channels = c);
  }
}

@NgModule({
  imports: [
    MatListModule,
    CommonModule
  ],
  exports: [
    ChannelListComponent
  ],
  declarations: [ChannelListComponent]
})
export class ChannelListModule {}
