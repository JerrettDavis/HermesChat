import {Component, NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";
import {ApiAuthorizationModule} from "../../api-authorization/api-authorization.module";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

@NgModule({
  exports: [
    NavMenuComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ApiAuthorizationModule
  ],
  declarations: [NavMenuComponent]
})
export class NavMenuModule {}
