import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IPart } from './part.model';

@Injectable()
export class PartDataService {
    constructor(private http: Http) { }

    getAllParts(): Observable<IPart[]> {
        return this.get('/app/data/parts.data.json');
    } 

    getBikeParts(bikeId: number): Observable<IPart[]> {
        return this.get('/app/data/parts.data.json')
            .map((parts: IPart[]) => parts.filter(part => part.bikeId == bikeId));
    }

    getPart(partId: number): Observable<IPart> {
        return this.get('/app/data/parts.data.json')
            .map((parts: IPart[]) => parts.find(part => part.partId == partId));
    }

    private get(url): Observable<any> {
        return this.http.get(url)
            .map((response: any) => response.json());
    }
}