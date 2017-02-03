import { OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { BikeDataService } from '../data/bike.service';
import { IRiderBike } from '../data/riderBike.model';

export abstract class BikeComponentBase implements OnInit {
    bike: IRiderBike = <any>{};

    constructor(
        protected bikeService: BikeDataService,
        private route: ActivatedRoute,
    ) { }

    ngOnInit(): void {
        this.route.params // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.bikeService.get(+params['id']))
            .subscribe((bike: IRiderBike) => this.bike = bike);
    }
}