import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { IPart } from '../data/part.model';

@Component({
    selector: 'part-list',
    templateUrl: './parts.component.html',
})
export class PartsComponent {
    @Input() parts: IPart[];
}