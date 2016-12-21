import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IBike } from './bike.model';

@Injectable()
export class BikeDataService {
    // private baseUrl: string = 'http://localhost:61083/api/bikes';
    
    constructor(private http: Http) { }

    getAllBikes(): Observable<IBike[]> {
        return this.http.get('/app/data/bikes.data.json')
            .map((response: any) => response.json());
    } 

    getBike(id: number): Observable<IBike> {
        return this.http.get('/app/data/bikes.data.json')
            .map((response: any) => response.json())
            .map((bikes: IBike[]) => bikes.find(bike => bike.bikeId == id));
    }
}