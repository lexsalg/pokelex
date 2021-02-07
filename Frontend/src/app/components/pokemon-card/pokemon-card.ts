import { Component, Input, OnInit } from '@angular/core';
import { Pokemon, PokemonTypes } from 'src/app/models';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-card',
  templateUrl: './pokemon-card.html',
  styleUrls: ['./pokemon-card.scss']
})
export class PokemonCard implements OnInit {

  pokemonTypes = PokemonTypes;
  @Input() pokemon: Pokemon;

  url = '';
  constructor(private api: ApiService) {
    this.url = this.api.getPokemeonImageUrl();
  }

  ngOnInit(): void {
  }

}
