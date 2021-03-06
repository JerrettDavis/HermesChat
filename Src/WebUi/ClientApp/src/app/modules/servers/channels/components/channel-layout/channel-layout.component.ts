import {Component, NgModule, OnInit} from '@angular/core';
import {MatSidenavModule} from "@angular/material/sidenav";
import {RouterModule} from "@angular/router";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatTooltipModule} from "@angular/material/tooltip";
import {ClipboardModule} from "@angular/cdk/clipboard";
import {UserToolbarModule} from "../user-toolbar/user-toolbar.component";
import {ServersSidebarModule} from "../servers-sidebar/servers-sidebar.component";
import {CreateServerDialogModule} from "../../../components/create-server-dialog/create-server-dialog.component";
import {ChannelListModule} from "@modules/servers/channels/components/channel-list/channel-list.component";

@Component({
  selector: 'app-channel-layout',
  templateUrl: './channel-layout.component.html',
  styleUrls: ['./channel-layout.component.scss']
})
export class ChannelLayoutComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }
}

@NgModule({
  exports: [
    ChannelLayoutComponent
  ],
  imports: [
    MatSidenavModule,
    RouterModule,
    MatDividerModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatTooltipModule,
    ClipboardModule,
    UserToolbarModule,

    CreateServerDialogModule,
    ServersSidebarModule,
    ChannelListModule
  ],
  declarations: [ChannelLayoutComponent]
})
export class ChannelLayoutModule {
}
