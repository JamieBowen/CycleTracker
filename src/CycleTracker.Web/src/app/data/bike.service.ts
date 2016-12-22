import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IBike } from './bike.model';

@Injectable()
export class BikeDataService {
    private baseUrl: string = '/api/bike';
    
    constructor(private http: Http) { }

    getAllBikes(): Observable<IBike[]> {
        return this.http.get(this.baseUrl)
            .map((response: any) => response.json());
    } 

    getBike(id: number): Observable<IBike> {
        return this.http.get(`${this.baseUrl}/${id}`)
            .map((response: any) => response.json());            
    }    
}