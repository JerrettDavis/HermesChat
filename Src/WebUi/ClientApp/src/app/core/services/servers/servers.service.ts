import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {Server} from "../../models/servers/server-model";
import {ApiService} from "../api.service";
import {CreateServerRequest} from "../../models/servers/requests/create-server-request.model";
import {map} from "rxjs/operators";
import {GetUserServersResponse} from "../../models/servers/responses/get-user-servers-response.model";
import {GetServerResponse} from "../../models/servers/responses/get-server-response.model";

@Injectable({
  providedIn: 'root'
})
export class ServersService {

  constructor(private _apiServer: ApiService) { }

  getServers(): Observable<Server[]> {
    return this._apiServer.get('/Api/Servers')
      .pipe(map((s: GetUserServersResponse) => s.servers));
  }

  getServer(serverId: string): Observable<Server> {
    return this._apiServer.get(`/Api/Servers/${serverId}`)
      .pipe(map((s: GetServerResponse) => s.server));
  }

  createServer(request: CreateServerRequest): Observable<Server> {
    return this._apiServer.post('/Api/Servers', request);
  }
}
