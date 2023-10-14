import { Injectable } from '@angular/core';
import { NbaViewModel } from '../models/nba.models';

@Injectable({
  providedIn: 'root',
})
export class NbaService {
  constructor() {}

  public getNbaPlayers(): NbaViewModel[] {
    const nbaPlayer: NbaViewModel[] = [
      {
        firstName: 'lebron',
        lastName: 'james',
        number: 6,
      },
      {
        firstName: 'carmelo',
        lastName: 'anthony',
        number: '00' as unknown as number,
      },
    ];

    return nbaPlayer;
  }
}
