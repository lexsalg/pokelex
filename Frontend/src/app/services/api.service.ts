import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment as env } from 'src/environments/environment';


import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ApiService {

    constructor(private http: HttpClient) { }

    getPokemones(): Observable<any[]> {
        const url = `${env.api}/pokemon`;
        return this.http.get<any[]>(url);
    }

    getPokemon(id: string): Observable<any> {
        const url = `${env.api}/pokemon/${id}`;
        return this.http.get<any>(url);
    }

    buscarPokemon(query: string): Observable<any[]> {
        const params = new HttpParams().set('query', query);
        const url = `${env.api}/pokemon`;
        return this.http.get<any[]>(url, { params });
    }

    cargarPokemonesBD(): Observable<any> {
        const url = `${env.api}/seed`;
        return this.http.get<any>(url);
    }

}

