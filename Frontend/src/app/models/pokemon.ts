import { Language } from "./language";
import { PokemonBase } from "./pokemon-base";
import { PokemonMove } from "./pokemon-move";

export class Pokemon {
  internalId: string;
  id: string;
  name: Language;
  type: string[];
  base: PokemonBase;
  color: string;
  move: PokemonMove;

  constructor() {

    this.internalId = null;
    this.id = null;
    this.name = null;
    this.type = [];
    this.base = null;
    this.color = null;
    this.move = new PokemonMove();
  }
}


