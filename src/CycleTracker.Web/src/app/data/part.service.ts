import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IPart } from './part.model';

@Injectable()
export class PartDataService {
    private baseUrl: string = '/api/part';

    constructor(private http: Http) { }

    get(id: number): Observable<IPart> {
        return this.http.get(`${this.baseUrl}/${id}`)
            .map((response: any) => response.json());
    }

}