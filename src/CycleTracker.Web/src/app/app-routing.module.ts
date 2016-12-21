import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BikesComponent } from './bikes/bikes.component';
import { BikeComponent } from './bikes/bike.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'bikes' },
  { path: 'bikes', component: BikesComponent },
  { path: 'bike/:id', component: BikeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { };

export const routingComponents = [BikesComponent, BikeComponent];