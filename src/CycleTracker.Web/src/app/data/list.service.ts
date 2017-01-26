import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs';

import { IListItem } from './listItem.model';

@Injectable()
export class ListDataService {
    private baseUrl: string = '/api/list';
    
    constructor(private http: Http) { }

    getPartTypes(): Observable<IListItem[]> {
        return this.http.get(`${this.baseUrl}/parttype`)
            .map((response: Response) => response.json());
    } 
}