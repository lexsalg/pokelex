import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // used for dropdowns

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { BlockUIModule } from 'ng-block-ui';


import { AppComponent } from './app.component';

import { BlockUi, ToolBar } from './components';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRouting } from './app.routing';
import { InicioPage, PokemonPage } from './pages';



const COMPONENTS = [
  InicioPage,
  PokemonPage,

  BlockUi,
  ToolBar,


];



@NgModule({
  declarations: [
    AppComponent,
    ...COMPONENTS
  ],
  imports: [
    BrowserModule,
    // BrowserAnimationsModule,
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
