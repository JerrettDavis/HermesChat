import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {LoggerModule, NgxLoggerLevel} from "ngx-logger";
import {AppComponent} from './app.component';
import {ApiAuthorizationModule} from '@auth/api-authorization.module';
import {AuthorizeInterceptor} from '@auth/authorize.interceptor';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AppRoutingModule} from "./app-routing.module";
import {NavMenuModule} from "./nav-menu/nav-menu.component";
import {RouterModule} from "@angular/router";
import {MatSidenavModule} from "@angular/material/sidenav";
import {ClipboardModule} from "@angular/cdk/clipboard";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    LoggerModule.forRoot({level: NgxLoggerLevel.DEBUG}),
    BrowserAnimationsModule,
    NavMenuModule,
    RouterModule,
    ClipboardModule,

    MatSidenavModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
