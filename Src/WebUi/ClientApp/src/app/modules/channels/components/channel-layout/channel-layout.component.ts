import {Component, NgModule, OnInit} from '@angular/core';
import {MatSidenavModule} from "@angular/material/sidenav";
import {RouterModule} from "@angular/router";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {MatToolbarModule} from "@angular/material/toolbar";
import {AuthorizeService, IUser} from "../../../../../api-authorization/authorize.service";
import {MatButtonModule} from "@angular/material/button";
import {MatTooltipModule} from "@angular/material/tooltip";
import {Clipboard, ClipboardModule} from "@angular/cdk/clipboard";
import {UserToolbarModule} from "../user-toolbar/user-toolbar.component";
import {MatDialog} from "@angular/material/dialog";
import {
  CreateServerDialogComponent,
  CreateServerDialogModule
} from "../../../servers/components/create-server-dialog/create-server-dialog.component";

@Component({
  selector: 'app-channel-layout',
  templateUrl: './channel-layout.component.html',
  styleUrls: ['./channel-layout.component.scss']
})
export class ChannelLayoutComponent implements OnInit {

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

    CreateServerDialogModule
  ],
  declarations: [ChannelLayoutComponent]
})
export class ChannelLayoutModule {
}
