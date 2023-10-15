import { TestBed } from '@angular/core/testing';

import { NbaService } from './nba.service';
import { HttpClientModule } from '@angular/common/http';
import { of } from 'rxjs';
import { NbaViewModel } from '../models/nba.models';

describe('NbaService', () => {
  let service: NbaService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    });
    service = TestBed.inject(NbaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('get should return players', () => {
    //arrange
    const vm: NbaViewModel[] = [
      { franchise: 'Celtics', lastName: 'Tatum', number: 0, surname: 'Jason' },
    ];

    spyOn(service, 'getNbaPlayers').and.returnValue(of(vm));
    //act
    service.getNbaPlayers().subscribe((players) => {
      //assert
      expect(players).toEqual(vm);
    });
  });
});
