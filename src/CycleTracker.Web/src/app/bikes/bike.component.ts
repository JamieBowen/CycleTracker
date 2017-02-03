import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

import { IBikePart } from '../data/bikePart.model';

@Component({
    selector: 'bike-view',
    templateUrl: './bike.component.html',
})
export class BikeComponent implements OnInit {
    bike: IBike = <any>{};

    constructor(
        private bikeService: BikeDataService,
        private route: ActivatedRoute,
    ) { }

    ngOnInit(): void {
        this.route.params // (+) converts string 'id' to a number
            .switchMap((params: Params) => {
                return this.bikeService.getWithParts(+params['id']);
            })
            .subscribe((bike: IBike) => {
                this.bike = bike;
            });
    }
}