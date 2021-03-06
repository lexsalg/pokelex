import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment as env } from 'src/environments/environment';


import { Observable } from 'rxjs';
import { Pokemon, PokemonColor, PokemonMove } from '../models';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ApiService {

    constructor(private http: HttpClient) { }

    getPokemones(pageNumber: any = 1, pageSize: any = 20): Observable<Pokemon[]> {
        const params = new HttpParams()
            .set('pnum', pageNumber)
            .set('psize', pageSize);
        const url = `${env.api}/pokemon/filter`;
        return this.http.get<Pokemon[]>(url, { params }).pipe(
            map(pokemons => {
                pokemons.forEach(p => { p.color = PokemonColor[(Math.random() * 10).toFixed(0)]; });
                return pokemons;
            }));
    }

    getPokemon(id: string): Observable<any> {
        const url = `${env.api}/pokemon/${id}`;
        return this.http.get<any>(url);
    }

    getPokemonMove(id: string): Observable<PokemonMove> {
        const url = `${env.api}/pokemonmove/${id}`;
        return this.http.get<PokemonMove>(url);
    }

    buscarPokemon(name = '', pageNumber: any = 1, pageSize: any = 20): Observable<Pokemon[]> {
        const params = new HttpParams()
            .set('name', name)
            .set('pnum', pageNumber)
            .set('psize', pageSize);
        const url = `${env.api}/pokemon/search`;
        return this.http.get<Pokemon[]>(url, { params }).pipe(
            map(pokemons => {
                pokemons.forEach(p => { p.color = PokemonColor[(Math.random() * 10).toFixed(0)]; });
                return pokemons;
            }));
    }


    cargarPokemonesBD(): Observable<any> {
        const url = `${env.api}/seed`;
        return this.http.get<any>(url);
    }

    borrarPokemonesBD(): Observable<any> {
        const url = `${env.api}/seed`;
        return this.http.delete<any>(url);
    }

    getPokemeonImageUrl() {
        return `${env.api}/image`;
    }

}

