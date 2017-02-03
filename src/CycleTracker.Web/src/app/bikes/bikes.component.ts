import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { RiderDataService } from '../data/rider.service';
import { IRider } from '../data/rider.model';
import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-list',
    templateUrl: './bikes.component.html',
    styles: ['tbody tr { cursor: pointer; }']
})
export class BikesComponent implements OnInit {
    rider: IRider;
    bikes: IBike[];

    constructor(
        private riderService: RiderDataService,
        private router: Router 
    ) { }

    ngOnInit(): void {
        this.riderService.getWithBikes(1).subscribe((rider) => {
            this.rider = rider;
            this.bikes = rider.bikes;
        });
        
    }

    onSelect(bike: IBike) {
        this.router.navigate(['/bike/view', bike.id]);
    }

}
