import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { delay, finalize } from 'rxjs/operators';
import { Pokemon } from 'src/app/models';

import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'inicio-page',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss']
})
export class InicioPage implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  pokemones: Pokemon[] = [];

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getPokemones();
  }


  getPokemones() {
    this.blockUI.start('Cargando...');

    const pageNumber = 1;
    const pageSize = 20;

    this.api.getPokemones(pageNumber, pageSize)
      .pipe(delay(1000))// CON FINES DEMOSTRACION
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(
        pokemones => {
          this.pokemones = pokemones;
          if (pokemones.length != 0) this.redirect();
        }
      )
  }

  cargar(message?: string) {
    this.blockUI.start('Cargando Pokemones...');
    this.api.cargarPokemonesBD()
      .pipe(delay(3000))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(res => this.redirect());
  }

  borrar(message?: string) {
    this.blockUI.start('Cargando Pokemones...');
    this.api.borrarPokemonesBD()
      .pipe(delay(1000))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(res => this.redirect());
  }

  redirect() {
    this.router.navigate(['/pokemones'])
  }
}
