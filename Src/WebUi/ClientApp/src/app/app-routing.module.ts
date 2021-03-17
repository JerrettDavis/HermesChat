import {NgModule} from '@angular/core';
import {PreloadAllModules, Route, RouterModule} from "@angular/router";

const routes: Route[] = [
  {
    path: '',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'channels',
    loadChildren: () => import('./modules/servers/channels/channels.module').then(m => m.ChannelsModule)
  }
]

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
