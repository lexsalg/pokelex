import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { delay, finalize, map } from 'rxjs/operators'
import { Pokemon } from 'src/app/models';

import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-page',
  templateUrl: './pokemon.page.html',
  styleUrls: ['./pokemon.page.scss']
})
export class PokemonPage implements OnInit {

  pokemones: Pokemon[] = [];
  pageNumber = 1;
  pageSize = 20;

  @BlockUI() blockUI: NgBlockUI;

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getPokemones(this.pageNumber, this.pageSize);
  }


  getPokemones(pageNumber, pageSize) {
    this.blockUI.start('Cargando...');
    
    this.api.getPokemones(pageNumber, pageSize)
      .pipe(delay(1000))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(
        res => {
          this.pokemones = res;
          if (res.length == 0) this.router.navigate(['/']);
        }
      )
  }
}
