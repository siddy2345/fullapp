import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayerGridComponent } from './components/player-grid/player-grid.component';
import { PlayerEditorComponent } from './components/player-editor/player-editor.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'players' },
  { path: 'players', component: PlayerGridComponent },
  { path: 'create-player', component: PlayerEditorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
