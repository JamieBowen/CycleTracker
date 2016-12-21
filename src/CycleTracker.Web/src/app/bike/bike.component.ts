import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

import { PartDataService } from '../data/part.service';

@Component({
    selector: 'bike-detail',
    templateUrl: './bike.component.html',
})
export class BikeComponent implements OnInit {
    bike: IBike;

    constructor(
        private bikeService: BikeDataService,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.route.params            
            .switchMap((params: Params) => this.bikeService.getBikeById(+params['id'])) // (+) converts string 'id' to a number
            .subscribe((bike: IBike) => this.bike = bike);
    }

}