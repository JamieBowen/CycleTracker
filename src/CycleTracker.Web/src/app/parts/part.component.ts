import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { PartDataService } from '../data/part.service';
import { IPart } from '../data/part.model';

@Component({
    selector: 'part-detail',
    templateUrl: './part.component.html'
})
export class PartComponent implements OnInit {
    part: IPart = <any>{};

    constructor(
        private partService: PartDataService,
        private route: ActivatedRoute,
    ) { }

    ngOnInit(): void {
        //this.route.params
    }

}