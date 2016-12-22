import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

import { PartDataService } from '../data/part.service';
import { IPart } from '../data/part.model';

@Component({
    selector: 'bike-view',
    templateUrl: './bike.component.html',
})
export class BikeComponent implements OnInit {
    bike: IBike = <any>{};
    parts: IPart[];

    constructor(
        private bikeService: BikeDataService,
        private partService: PartDataService,
        private route: ActivatedRoute,
    ) { }

    ngOnInit(): void {
        this.route.params // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.bikeService.getBike(+params['id']))
            .switchMap((bike: IBike) => {
                this.bike = bike;
                return this.partService.getBikeParts(bike.id);
            })
            .subscribe((parts: IPart[]) => this.parts = parts);
    }
}