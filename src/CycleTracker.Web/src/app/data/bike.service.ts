import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IBike } from './bike.model';

@Injectable()
export class BikeDataService {
    private baseUrl: string = '/api/bike';
    
    constructor(private http: Http) { }

    getAll(): Observable<IBike[]> {
        return this.http.get(this.baseUrl)
            .map((response: Response) => response.json());
    } 

    get(id: number): Observable<IBike> {
        return this.http.get(`${this.baseUrl}/${id}`)
            .map((response: Response) => response.json());            
    }    

    add(bike: IBike): Observable<IBike> {
        return this.http.post(this.baseUrl, bike)
            .map((response: Response) => response.json());
    }

    update(bike: IBike): Observable<void> {
        return this.http.put(this.baseUrl, bike)
            .map((response: Response) => null);
    }
    
    delete(id: number): Observable<void> {
        return this.http.delete(`${this.baseUrl}/${id}`)
            .map((response: Response) => null);
    }
}