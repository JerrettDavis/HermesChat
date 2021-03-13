import {NgModule} from '@angular/core';
import {Route, RouterModule} from "@angular/router";
import {AuthorizeGuard} from "../../../api-authorization/authorize.guard";
import {ChannelsHomePageModule, HomeComponent} from "./pages/home/home.component";
import {ChannelLayoutComponent, ChannelLayoutModule} from "./components/channel-layout/channel-layout.component";

const routes: Route[] = [
  {
    path: '',
    component: ChannelLayoutComponent,
    children: [
      {path: '', component: HomeComponent, canActivate: [AuthorizeGuard]}
    ]
  }];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),

    ChannelsHomePageModule,
    ChannelLayoutModule
  ]
})
export class ChannelsRoutingModule {
}
