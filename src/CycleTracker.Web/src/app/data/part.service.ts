import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IPart } from './part.model';

@Injectable()
export class PartDataService {
    constructor(private http: Http) { }

    get(id: number): Observable<IPart> {
        return this.http.get('/app/data/parts.data.json')
            .map((response: any) => response.json())
            .map((parts: IPart[]) => parts.find(part => part.id == id));
    }

    getBikeParts(bikeId: number): Observable<IPart[]> {
        return this.http.get('/app/data/parts.data.json')
            .map((response: any) => response.json())
            .map((parts: IPart[]) => parts.filter(part => part.bikeId == bikeId));
    }

}