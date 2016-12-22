import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { BikeComponentBase } from './bike-base.component';
import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-edit',
    templateUrl: './bike-edit.component.html'
})
export class BikeEditComponent extends BikeComponentBase {
    constructor(
        bikeService: BikeDataService, 
        route: ActivatedRoute,
    ) { 
        super(bikeService, route);
    }

    update(bike: IBike): void {
        this.bikeService.update(bike).subscribe(
            () => console.log('Update successful'),
            () => console.log('Update failed')
        );
    }
}