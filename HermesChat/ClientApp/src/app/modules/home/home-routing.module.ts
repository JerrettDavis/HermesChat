import {NgModule} from '@angular/core';
import {Route, RouterModule} from "@angular/router";
import {HomeComponent, HomePageModule} from "./pages/home/home.component";
import {AuthorizeGuard} from "../../../api-authorization/authorize.guard";
import {CounterComponent, CounterPageModule} from "./pages/counter/counter.component";
import {FetchDataComponent, FetchDataPageModule} from "./pages/fetch-data/fetch-data.component";

const routes: Route[] = [
  { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthorizeGuard] },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] }];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),

    CounterPageModule,
    FetchDataPageModule,
    HomePageModule
  ]
})
export class HomeRoutingModule {
}
