import {Injectable} from '@angular/core';
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {AuthorizeService} from "@auth/authorize.service";

@Injectable({
  providedIn: 'root'
})
export class HubBuilderService {

  constructor(private _authorizeService: AuthorizeService) {
  }

  async build(url: string): Promise<HubConnection> {
    const accessToken = this._authorizeService.getAccessToken().toPromise();
    return new HubConnectionBuilder()
      .withUrl(url, {accessTokenFactory: () => accessToken})
      .withAutomaticReconnect()
      .build();
  }
}
