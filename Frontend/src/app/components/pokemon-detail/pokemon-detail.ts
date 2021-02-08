import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Pokemon, PokemonTypes } from 'src/app/models';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-detail',
  templateUrl: './pokemon-detail.html',
  styleUrls: ['./pokemon-detail.scss']
})
export class PokemonDetail implements OnInit {

  @Input() pokemon: Pokemon;
  pokemonTypes = PokemonTypes;
  url = '';

  constructor(private api: ApiService, public activeModal: NgbActiveModal) {
    this.url = this.api.getPokemeonImageUrl();
  }

  ngOnInit(): void {
  }

}
