import { Injectable } from '@angular/core';
import {HubConnection} from "@microsoft/signalr";
import {Observable} from "rxjs";
import {AuthorizeService} from "../../../api-authorization/authorize.service";

@Injectable({
  providedIn: 'root'
})
export class HubBuilderService {

  constructor(private _authorizeService: AuthorizeService) { }

  // build(url: string): Observable<HubConnection> {
  //   this._authorizeService.getAccessToken()
  //     .subscribe(async)
  // }
}
