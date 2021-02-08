import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { delay, finalize, tap } from 'rxjs/operators';
import { Pokemon, PokemonTypes } from 'src/app/models';
import { ApiService } from 'src/app/services/api.service';
import { PokemonDetail } from '../pokemon-detail/pokemon-detail';

@Component({
  selector: 'pokemon-card',
  templateUrl: './pokemon-card.html',
  styleUrls: ['./pokemon-card.scss']
})
export class PokemonCard implements OnInit {

  @Input() pokemon: Pokemon;
  pokemonTypes = PokemonTypes;
  url = '';

  @BlockUI() blockUI: NgBlockUI;
  scrollObserver: IntersectionObserver;


  constructor(private api: ApiService, private modalService: NgbModal) {
    this.url = this.api.getPokemeonImageUrl();
  }

  ngOnInit(): void {
  }

  detalle() {
    this.getPokemonMove(this.pokemon.id).subscribe(() => this.openDetail());
  }

  openDetail() {
    const modalRef = this.modalService.open(PokemonDetail, { windowClass: 'modal-container' });
    modalRef.componentInstance.pokemon = this.pokemon;
  }

  getPokemonMove(id) {
    this.blockUI.start(`Cargando Datos de ${this.pokemon.name.english} ...`);

    return this.api.getPokemonMove(id)
      .pipe(delay(1500))
      .pipe(finalize(() => this.blockUI.stop()))
      .pipe(tap(move => this.pokemon.move = move))
  }

  setImageId(id: string) {
    if (id.length == 1) return `${this.url}/00${id}`;
    else if (id.length == 2) return `${this.url}/0${id}`;
    else if (id.length == 3) return `${this.url}/${id}`;
  }
}
