import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CarBrand, CarClass, ICarModel } from '../models/icar-model';
import { CarModelService } from '../services/car-model.service';

@Component({
  selector: 'app-car-model-list',
  templateUrl: './car-model-list.component.html',
  styleUrls: ['./car-model-list.component.css']
})
export class CarModelListComponent implements OnInit {

  isLoggedIn = false;
  filteredListings: ICarModel[] = [
    {
      modelName: 'n1',
      brand: CarBrand.Audi,
      description: "dsfdzfsd",
      class: CarClass.AClass,
      modelCode: "dasf3efd",
      price: 11,
      active: true,
      dateOfManufacturing: new Date(),
      features: "dsfdg",
      sortOrder: 1,
      imageUrls: ["https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdEMRuNx-lR_xOWqw0yXM_hfDBP5FpzVDWjg&s",
        "dsfdfg","dsf"      ]
    }
  ];
  allListings: ICarModel[] = [
    {
      modelName: 'n1',
      brand: CarBrand.Audi,
      description: "dsfdzfsd",
      class: CarClass.AClass,
      modelCode: "dasf3efd",
      price: 11,
      active: true,
      dateOfManufacturing: new Date(),
      features: "dsfdg",
      sortOrder: 1,
      imageUrls: ["https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdEMRuNx-lR_xOWqw0yXM_hfDBP5FpzVDWjg&s",
        "dsfdfg", "dsf"]
    }];
  modelName: string = '';
  modelCode: string = '';

  constructor(private carModelService: CarModelService, private router: Router) { }

  ngOnInit(): void {
    this.isLoggedIn = Boolean(localStorage.getItem("isLoggedIn"));
    this.getAllCars();
  }

  logOut() {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  filterListings() {
    this.filteredListings = this.allListings.filter(item => {
      const matchesModelName = !this.modelName || item.modelName.toLowerCase().includes(this.modelName.toLowerCase());
      const matchesModelCode = !this.modelCode || item.modelCode.toLowerCase().includes(this.modelCode.toLowerCase());
      return matchesModelName && matchesModelCode;
    });
  }

  getAllCars() {
    this.carModelService.getAllCarModel().subscribe(res => {
      console.log('all cars ', res);
      this.allListings = res;
      this.filteredListings = res;
    },
      error => {
        alert(`an error has occored ${error}`);
      })
    
  }

  view() {
    this.router.navigate(['view']);
  }

}
