import { Language } from "./language";
import { PokemonBase } from "./pokemon-base";

export class Pokemon {
  internalId: string;
  id: string;
  name: Language;
  type: string[];
  base: PokemonBase;
  color: string;
}


