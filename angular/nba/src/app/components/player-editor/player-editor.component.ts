import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NbaService } from 'src/app/services/nba.service';
import { NbaViewModel } from 'src/app/models/nba.models';
import { finalize, take } from 'rxjs';

@Component({
  selector: 'app-player-editor',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './player-editor.component.html',
  styleUrls: ['./player-editor.component.css'],
})
export class PlayerEditorComponent {
  public form = new FormGroup({
    surname: new FormControl(),
    lastName: new FormControl(),
    number: new FormControl(),
    franchise: new FormControl(),
  });

  constructor(private service: NbaService) {}

  public onCreate(): void {
    const nbaPlayerViewModel: NbaViewModel = {
      surname: this.form.value.surname,
      lastName: this.form.value.lastName,
      number: this.form.value.number as number,
      franchise: this.form.value.franchise,
    };

    this.service.createNbaPlayer(nbaPlayerViewModel).pipe(take(1)).subscribe();
  }
}
