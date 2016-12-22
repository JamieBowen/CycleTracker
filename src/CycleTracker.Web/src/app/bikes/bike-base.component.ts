import { OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

export abstract class BikeComponentBase implements OnInit {
    bike: IBike = <any>{};
    protected bikeService: BikeDataService;

    constructor(
        bikeService: BikeDataService,
        private route: ActivatedRoute,
    ) { 
        this.bikeService = bikeService;
    }

    ngOnInit(): void {
        this.route.params // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.bikeService.getBike(+params['id']))
            .subscribe((bike: IBike) => this.bike = bike);
    }
}