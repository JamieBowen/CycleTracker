import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { PartsComponent } from './parts/parts.component';
import { BikeDataService } from './data/bike.service';
import { PartDataService } from './data/part.service';

// import all operators during development
// this runs a script that has side effects 
// which makes operators available in all modules
import 'rxjs/Rx';

@NgModule({
  declarations: [
    AppComponent,
    PartsComponent,
    routingComponents,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
  ],
  providers: [
    BikeDataService,
    PartDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
