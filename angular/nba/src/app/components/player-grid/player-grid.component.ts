import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NbaViewModel } from 'src/app/models/nba.models';
import { NbaService } from 'src/app/services/nba.service';
import { GridModule } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-player-grid',
  standalone: true,
  imports: [CommonModule, GridModule],
  templateUrl: './player-grid.component.html',
  styleUrls: ['./player-grid.component.css'],
})
export class PlayerGridComponent implements OnInit {
  public nbaPlayers: NbaViewModel[] = [];

  constructor(private nbaService: NbaService) {}

  public ngOnInit(): void {
    this.nbaPlayers = this.nbaService.getNbaPlayers();
    console.log(this.nbaPlayers);
  }
}
