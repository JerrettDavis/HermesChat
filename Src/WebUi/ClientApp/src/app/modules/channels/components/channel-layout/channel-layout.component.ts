import {Component, NgModule, OnInit} from '@angular/core';
import {MatSidenavModule} from "@angular/material/sidenav";
import {RouterModule} from "@angular/router";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {MatToolbarModule} from "@angular/material/toolbar";
import {AuthorizeService, IUser} from "../../../../../api-authorization/authorize.service";

@Component({
  selector: 'app-channel-layout',
  templateUrl: './channel-layout.component.html',
  styleUrls: ['./channel-layout.component.scss']
})
export class ChannelLayoutComponent implements OnInit {
  user: IUser;

  constructor(private _authService: AuthorizeService) { }

  ngOnInit(): void {
    this._authService.getUser()
      .subscribe(u => this.user = u);
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
    MatToolbarModule
  ],
  declarations: [ChannelLayoutComponent]
})
export class ChannelLayoutModule {}
