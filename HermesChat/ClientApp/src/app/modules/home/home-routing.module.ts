import {NgModule} from '@angular/core';
import {Route, RouterModule} from "@angular/router";
import {HomeComponent, HomePageModule} from "./pages/home/home.component";


const routes: Route[] = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  }];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),

    HomePageModule
  ]
})
export class HomeRoutingModule {
}
