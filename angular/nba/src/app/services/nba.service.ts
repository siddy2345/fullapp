import { Injectable, OnDestroy } from '@angular/core';
import { NbaViewModel } from '../models/nba.models';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class NbaService {
  private url = 'players';

  constructor(private http: HttpClient) {}

  public getNbaPlayers(): Observable<NbaViewModel[]> {
    return this.http.get<NbaViewModel[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createNbaPlayer(player: NbaViewModel): Observable<number> {
    // const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.post<number>(
      `${environment.apiUrl}/${this.url}`,
      player
      // { headers }
    );
  }
}
