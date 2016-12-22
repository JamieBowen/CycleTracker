import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { BikeComponentBase } from './bike-base.component';
import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-delete',
    templateUrl: './bike-delete.component.html'
})
export class BikeDeleteComponent extends BikeComponentBase {
    constructor(
        bikeService: BikeDataService, 
        route: ActivatedRoute,
    ) { 
        super(bikeService, route);
    }

    delete(): void {
        this.bikeService.delete(this.bike.id).subscribe(
            () => console.log('Delete successful'),
            () => console.log('Delete failed')
        );
    }
}