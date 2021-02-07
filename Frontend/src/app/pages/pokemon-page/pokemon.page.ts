import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { delay, finalize, map } from 'rxjs/operators'

import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-page',
  templateUrl: './pokemon.page.html',
  styleUrls: ['./pokemon.page.scss']
})
export class PokemonPage implements OnInit {

  data = [];

  @BlockUI() blockUI: NgBlockUI;

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
          this.data = res;
          if (res.length == 0) this.router.navigate(['/']);

        }
      )
  }
}
