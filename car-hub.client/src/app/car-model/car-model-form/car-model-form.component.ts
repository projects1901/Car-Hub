import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarBrand, CarClass, ICarModel } from '../../models/icar-model';
import { CarModelService } from '../../services/car-model.service';

@Component({
  selector: 'app-car-model-form',
  templateUrl: './car-model-form.component.html',
  styleUrls: ['./car-model-form.component.css']
})
export class CarModelFormComponent implements OnInit {

  carModel: ICarModel = {
    brand: CarBrand.None,
    class: CarClass.None, 
    modelName: '',
    modelCode: '',
    description: '',
    features: '',
    price: 0,
    dateOfManufacturing: null,
    active: true,
    sortOrder: 0,
    imageUrls: []
  };

  isLoggedIn = false;
  CarBrand = CarBrand; 
  CarClass = CarClass; 

  constructor(private carModelService: CarModelService, private router: Router) { }

  ngOnInit(): void {
    this.isLoggedIn = Boolean(localStorage.getItem("isLoggedIn"));
  }

  onSubmit() {
    this.carModelService.addCarModel(this.carModel).subscribe(response => {
      console.log('Car model added!', response);
      
    }, error => {
      alert(`Error adding car model ${error}`);
      
    });
  }

  onFileChange(event: any) {
    const files = event.target.files;
    if (files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        if (files[i].size > 5 * 1024 * 1024) { // 5MB limit
          alert('File size must be less than 5MB');
          return;
        }
        var reader = new FileReader();
        reader.readAsDataURL(files[0]);
        reader.onload = (event: any) => {
          this.carModel.imageUrls?.push(event.target.result);
        }        
      }
      
    }
  }

  logOut() {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  view() {
    this.router.navigate(['view']);
  }

}
