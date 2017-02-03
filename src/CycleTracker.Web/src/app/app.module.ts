import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { BikeInputComponent } from './bikes/bike-input.component';
import { PartsComponent } from './parts/parts.component';
import { BikePartsComponent } from './parts/bikeParts.component';
import { RiderDataService } from './data/rider.service';
import { BikeDataService } from './data/bike.service';
import { PartDataService } from './data/part.service';
import { BikePartDataService } from './data/bikePart.service';

// import all operators during development
// this runs a script that has side effects 
// which makes operators available in all modules
import 'rxjs/Rx';

@NgModule({
  declarations: [
    AppComponent,
    BikeInputComponent,
    PartsComponent,
    BikePartsComponent,
    routingComponents,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
  ],
  providers: [
    RiderDataService,
    BikeDataService,
    PartDataService,
    BikePartDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
