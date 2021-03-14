import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _http: HttpClient) { }

  private static formatErrors(error: any) {
    let err: any = error.error;
    if (error.status === 404)
      err = { 'NotFoundException': 'The page or resource was not found. If this error persists, please email the webmaster.'};
    return throwError(err);
  }

  public get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this._http.get(path, {params})
      .pipe(catchError(ApiService.formatErrors));
  }

  public getFile(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this._http.get(path, {params, responseType: 'blob'})
      .pipe(catchError(ApiService.formatErrors));
  }

  public put(path: string, body: Object = {}): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.put(
      path,
        JSON.stringify(body),
        {headers: headers}
    ).pipe(catchError(ApiService.formatErrors));
  }

  public patch(path: string, body: Object = {}): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.patch(
      path,
      JSON.stringify(body),
      {headers: headers}
    ).pipe(catchError(ApiService.formatErrors));
  }

  public post(path: string, body: Object = {}): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.post(
      path,
      JSON.stringify(body),
      {headers: headers}
    ).pipe(catchError(ApiService.formatErrors));
  }

  public delete(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this._http.delete(path, {params})
      .pipe(catchError(ApiService.formatErrors));
  }
}
