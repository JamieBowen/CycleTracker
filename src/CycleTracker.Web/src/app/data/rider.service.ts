import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IRider } from './rider.model';

@Injectable()
export class RiderDataService {
    private baseUrl: string = '/api/rider';
    
    constructor(private http: Http) { }
    
    get(id: number): Observable<IRider> {
        return this.http.get(`${this.baseUrl}/${id}`)
            .map((response: Response) => response.json());            
    }    

    getWithBikes(id: number): Observable<IRider> {
        return this.http.get(`${this.baseUrl}/${id}/bikes`)
            .map((response: Response) => response.json());            
    }

    // add(rider: IRider): Observable<IRider> {
    //     return this.http.post(this.baseUrl, rider)
    //         .map((response: Response) => response.json());
    // }

    // update(rider: IRider): Observable<void> {
    //     return this.http.put(this.baseUrl, rider)
    //         .map((response: Response) => null);
    // }
    
    // delete(id: number): Observable<void> {
    //     return this.http.delete(`${this.baseUrl}/${id}`)
    //         .map((response: Response) => null);
    // }
}