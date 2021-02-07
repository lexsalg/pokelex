import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { delay, finalize } from 'rxjs/operators';

import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'inicio-page',
  templateUrl: './inicio.page.html',
  styleUrls: ['./inicio.page.scss']
})
export class InicioPage implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  datos = [];

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getPokemones();
  }


  getPokemones() {
    this.blockUI.start('Cargando...');
    this.api.getPokemones()
      .pipe(delay(1000))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(
        res => {
          this.datos = res;
          if (res.length != 0) this.redirect();
        }
      )
  }

  cargar(message?: string) {
    this.blockUI.start('Cargando Pokemones...');
    this.api.cargarPokemonesBD()
      .pipe(delay(1000))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(res => this.redirect());
  }

  redirect() {
    this.router.navigate(['/pokemones'])
  }
}
