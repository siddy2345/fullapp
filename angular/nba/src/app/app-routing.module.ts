import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayerGridComponent } from './components/player-grid/player-grid.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'players' },
  { path: 'players', component: PlayerGridComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
