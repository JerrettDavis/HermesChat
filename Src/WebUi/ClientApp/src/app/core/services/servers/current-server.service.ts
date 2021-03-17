import {Injectable} from '@angular/core';
import {Observable, of} from "rxjs";
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {map, switchMap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class CurrentServerService {
  private _navigationEnd: Observable<NavigationEnd>;

  get server(): Observable<string | null> {
    // prototype, probably not what we want.
    return this._navigationEnd
      .pipe(
        map(() => this._route.root),
        map(root => root.firstChild),
        switchMap(firstChild => {
          if (firstChild && firstChild){
            const targetRoute = firstChild.firstChild;
            return targetRoute.paramMap.pipe(map(paramMap => paramMap.get('serverId')));
          }
          else
            return of(null);
        })
      );
  }

  constructor(private _router: Router,
              private _route: ActivatedRoute) {
  }
}
