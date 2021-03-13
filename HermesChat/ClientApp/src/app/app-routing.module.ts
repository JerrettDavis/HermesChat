import {NgModule} from '@angular/core';
import {PreloadAllModules, Route, RouterModule} from "@angular/router";
import {HomeModule} from "./modules/home/home.module";
import {ChannelsModule} from "./modules/channels/channels.module";

const routes: Route[] = [
  {
    path: '',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'channels',
    loadChildren: () => import('./modules/channels/channels.module').then(m => m.ChannelsModule)
  }]

@NgModule({
  declarations: [],
  imports: [
    RouterModule,
    RouterModule.forRoot(
      routes,
      {
        preloadingStrategy: PreloadAllModules,
        relativeLinkResolution: 'legacy'
      }
    )
  ]
})
export class AppRoutingModule {
}
