import {Component, NgModule, OnInit} from '@angular/core';
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {AuthorizeService} from "../../../../../api-authorization/authorize.service";
import {Router, RouterModule} from "@angular/router";
import {NGXLogger} from "ngx-logger";
import {ApplicationPaths} from "../../../../../api-authorization/api-authorization.constants";
import {fadeInAnimation} from "../../../../core/animations/fade-in.animation";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [fadeInAnimation],
  host: { '[@fadeInAnimation]': '' }
})
export class HomeComponent implements OnInit {
  loginPath: string[] = ApplicationPaths.LoginPathComponents;
  registerPath: string[] = ApplicationPaths.RegisterPathComponents;

  constructor(private _authorize: AuthorizeService,
              private _router: Router,
              private _logger: NGXLogger) {
  }

  ngOnInit(): void {
    this._logger.info('Checking if already signed in');
    this._authorize.isAuthenticated()
      .subscribe(authenticated => {
        if (authenticated) {
          this._router.navigate(['/', 'channels']).then(_ =>
            this._logger.info('Already authenticated, sending to channels'));
        } else {
          this._logger.info('User is not authenticated');
        }
      });
  }
}

@NgModule({
  imports: [
    MatCardModule,
    MatButtonModule,
    RouterModule
  ],
  declarations: [HomeComponent]
})
export class HomePageModule {
}
