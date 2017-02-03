import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IBikePart } from './bikePart.model';

@Injectable()
export class BikePartDataService {
    private baseUrl: string = '/api/bikepart';

    constructor(private http: Http) { }

    get(id: number): Observable<IBikePart> {
        return this.http.get(`${this.baseUrl}/${id}`)
            .map((response: any) => response.json());
    }

}