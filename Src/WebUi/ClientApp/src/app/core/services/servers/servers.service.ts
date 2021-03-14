import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {Server} from "../../models/servers/server-model";
import {ApiService} from "../api.service";
import {CreateServerRequest} from "../../models/servers/requests/create-server-request.model";

@Injectable({
  providedIn: 'root'
})
export class ServersService {

  constructor(private _apiServer: ApiService) { }

  createServer(request: CreateServerRequest): Observable<Server> {
    return this._apiServer.post('/Api/Servers', request);
  }
}
