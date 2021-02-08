import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { BlockUIModule } from 'ng-block-ui';


import { AppComponent } from './app.component';

import { BlockUi, PokemonCard, PokemonFilter, ToolBar } from './components';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRouting } from './app.routing';
import { InicioPage, PokemonPage } from './pages';
import { DeferLoadDirective } from './services/defer-load.directive';
import { PokemonDetail } from './components/pokemon-detail/pokemon-detail';



const COMPONENTS = [
  InicioPage,
  PokemonPage,
  PokemonCard,
  PokemonFilter,
  PokemonDetail,

  BlockUi,
  ToolBar,

  DeferLoadDirective

];



@NgModule({
  declarations: [
    AppComponent,
    ...COMPONENTS
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRouting,
    NgbModule,
    BlockUIModule.forRoot({ template: BlockUi })
  ],
  entryComponents: [
    BlockUi
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
