import {Component, NgModule, OnInit} from '@angular/core';
import {Clipboard} from "@angular/cdk/clipboard";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatTooltipModule} from "@angular/material/tooltip";
import {MatButtonModule} from "@angular/material/button";
import {AuthorizeService, IUser} from "@auth/authorize.service";

@Component({
  selector: 'app-user-toolbar',
  templateUrl: './user-toolbar.component.html',
  styleUrls: ['./user-toolbar.component.scss']
})
export class UserToolbarComponent implements OnInit {
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
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatTooltipModule,
    MatButtonModule
  ],
  exports: [
    UserToolbarComponent
  ],
  declarations: [UserToolbarComponent]
})
export class UserToolbarModule {}
