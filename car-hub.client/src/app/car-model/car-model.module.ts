import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarModelRoutingModule } from './car-model-routing.module';
import { CarModelFormComponent } from './car-model-form/car-model-form.component';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../navbar/navbar.component';
import { AppModule } from '../app.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [CarModelFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    CarModelRoutingModule,
    SharedModule
  ]
})
export class CarModelModule { }
