import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InicioPage, PokemonPage } from './pages';

const routes: Routes = [
  {
    path: '', component: InicioPage,
  },
  {
    path: 'pokemones', component: PokemonPage,
  },
  { path: '**', component: InicioPage }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})

export class AppRouting { }
