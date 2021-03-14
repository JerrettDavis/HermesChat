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

@Component({
  selector: 'app-channel-layout',
  templateUrl: './channel-layout.component.html',
  styleUrls: ['./channel-layout.component.scss']
})
export class ChannelLayoutComponent implements OnInit {
  user: IUser;

  private _usernameHasBeenCopied: boolean;


  get copyUsernameMessage(): string {
    return !this._usernameHasBeenCopied ?
      'Click to copy username.' :
      'Username Copied!'
  }

  get tooltipClass(): string {
    return this._usernameHasBeenCopied ?
      'tooltip-success' :
      '';
  }

  constructor(private _authService: AuthorizeService,
              private _clipboard: Clipboard) {
  }

  ngOnInit(): void {
    this._authService.getUser()
      .subscribe(u => {
        this.user = u
      });
  }

  copyUsername(): void {
    this._usernameHasBeenCopied = true;
    this._clipboard.copy(this.user.name + '#' + this.user.userIdentifier);
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
    UserToolbarModule
  ],
  declarations: [ChannelLayoutComponent]
})
export class ChannelLayoutModule {
}
