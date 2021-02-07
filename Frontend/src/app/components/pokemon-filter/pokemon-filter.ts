import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/models';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'pokemon-filter',
  templateUrl: './pokemon-filter.html',
  styleUrls: ['./pokemon-filter.scss']
})
export class PokemonFilter implements OnInit {

  @Input() pokemon: Pokemon;

  url = '';
  constructor(private api: ApiService) {
    this.url = this.api.getPokemeonImageUrl();
  }

  ngOnInit(): void { }
}
