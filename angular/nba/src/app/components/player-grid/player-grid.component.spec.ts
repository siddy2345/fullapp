import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerGridComponent } from './player-grid.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';

describe('PlayerGridComponent', () => {
  let component: PlayerGridComponent;
  let fixture: ComponentFixture<PlayerGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlayerGridComponent, HttpClientModule],
    }).compileComponents();

    fixture = TestBed.createComponent(PlayerGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
