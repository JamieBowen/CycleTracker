import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { IBikePart } from '../data/bikePart.model';

@Component({
    selector: 'bike-part-list',
    templateUrl: './bikeParts.component.html',
})
export class BikePartsComponent {
    @Input() bikeParts: IBikePart[];
}