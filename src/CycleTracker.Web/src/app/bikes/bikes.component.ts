import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-list',
    templateUrl: './bikes.component.html',
    styles: ['tbody tr { cursor: pointer; }']
})
export class BikesComponent implements OnInit {
    bikes: Observable<IBike[]>;

    constructor(
        private bikeService: BikeDataService,
        private router: Router 
    ) { }

    ngOnInit(): void {
        this.bikes = this.bikeService.getAllBikes(); 
    }

    onSelect(bike: IBike) {
        this.router.navigate(['/bike', bike.bikeId]);
    }

}
