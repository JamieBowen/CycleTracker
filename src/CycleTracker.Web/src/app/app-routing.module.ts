import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BikesComponent } from './bikes/bikes.component';
import { BikeComponent } from './bikes/bike.component';
import { BikeAddComponent } from './bikes/bike-add.component';
import { BikeEditComponent } from './bikes/bike-edit.component';
import { BikeDeleteComponent } from './bikes/bike-delete.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'bikes' },
  { path: 'bikes', component: BikesComponent },
  { path: 'bike/:id', component: BikeComponent },
  { path: 'bike/add', component: BikeAddComponent},
  { path: 'bike/edit/:id', component: BikeEditComponent },
  { path: 'bike/delete/:id', component: BikeDeleteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { };

export const routingComponents = [BikesComponent, BikeComponent, BikeAddComponent, BikeEditComponent, BikeDeleteComponent];