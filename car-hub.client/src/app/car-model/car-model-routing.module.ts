import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { CarModelFormComponent } from './car-model-form/car-model-form.component';

const routes: Routes = [
  {
    path: '',
    component: CarModelFormComponent,
    canActivate: [AuthGuard]  // Protect this route with AuthGuard
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarModelRoutingModule { }
