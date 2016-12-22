import { Component, Input, Output, EventEmitter } from '@angular/core';

import { IBike } from '../data/bike.model';

@Component({
    selector: 'bike-input',
    templateUrl: './bike-input.component.html'
})
export class BikeInputComponent {
    @Input() bike: IBike;
    @Input() header: string;   
    @Output() bikeChange = new EventEmitter<IBike>(); 

    save(): void {
        this.bikeChange.emit(this.bike);
    }
}