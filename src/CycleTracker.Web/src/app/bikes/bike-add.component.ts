import { Component } from '@angular/core';

import { BikeDataService } from '../data/bike.service';
import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-add',
    templateUrl: './bike-add.component.html'
})
export class BikeAddComponent {
    bike: IBike;

    constructor(private bikeService: BikeDataService) { 
        this.bike = <any>{};
    }

    add(bike: IBike): void {
        this.bikeService.add(bike).subscribe(
            () => console.log('Add successful'),
            () => console.log('Add failed')
        );
    }
}