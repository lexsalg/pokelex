import { AfterViewInit, Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

import { delay, finalize } from 'rxjs/operators'
import { Pokemon } from 'src/app/models';

import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-page',
  templateUrl: './pokemon.page.html',
  styleUrls: ['./pokemon.page.scss']
})
export class PokemonPage implements OnInit, AfterViewInit {

  pokemones: Pokemon[] = [];
  pageNumber = 1;
  pageSize = 20;

  lastElementId = "0";


  @BlockUI() blockUI: NgBlockUI;

  scrollObserver: IntersectionObserver;

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getPokemones(this.pageNumber, this.pageSize);
  }

  ngAfterViewInit() {
    this.scrollObserver = new IntersectionObserver(entries => this.observerAction(entries));
  }

  getPokemones(pageNumber, pageSize) {
    this.blockUI.start('Cargando...');

    this.api.getPokemones(pageNumber, pageSize)
      .pipe(delay(100))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(
        res => {
          this.pokemones = [...this.pokemones, ...res];
          this.observeLastElement(res);

          if (res.length == 0) this.router.navigate(['/']);
        }
      )
  }

  observerAction(entries: any[]) {

    const el = entries[0];
    if (el.isIntersecting) {
      this.pageNumber++;
      this.scrollObserver.unobserve(document.getElementById(this.lastElementId))
      this.getPokemones(this.pageNumber, this.pageSize);
    }
  }


  observeLastElement(list: Pokemon[]) {
    if (list.length > 0) {
      const lastElement = list[list.length - 1];
      this.lastElementId = lastElement.id
      setTimeout(() => {
        this.scrollObserver.observe(document.getElementById(lastElement.id))
      }, 0);
    }
  }


  filterChange(value) {
    try {
      this.scrollObserver.unobserve(document.getElementById(this.lastElementId))
    } catch (error) {
    }
    this.pageNumber = 1;
    this.pokemones = [];
    this.buscarPokemones(value, this.pageNumber, this.pageSize)

  }

  buscarPokemones(nombre, pageNumber, pageSize) {
    this.blockUI.start('Cargando...');

    this.api.buscarPokemon(nombre, pageNumber, pageSize)
      .pipe(delay(100))
      .pipe(finalize(() => this.blockUI.stop()))
      .subscribe(
        res => {
          this.pokemones = [...this.pokemones, ...res];
          if (nombre == '' || nombre == null)
            this.observeLastElement(res);
          // if (res.length == 0) {
          //   alert('No se encontraron resultados para la búsqueda');
          // }
        }
      )
  }

}
