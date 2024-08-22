import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CarModelService } from '../services/car-model.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  fullName: string = "";
  username: string = "";
  password: string = "";

  constructor(private authService: CarModelService, private router: Router) { }

  ngOnInit() { }

  register(form: NgForm) {
    if (form.valid) {
      this.authService.register(this.fullName, this.username, this.password).subscribe(
        response => {
          console.log("Registration successful");
          
          form.resetForm();

          this.router.navigate(['login']);
        },
        error => {
          console.log('Registration failed:', error);
          alert(`Registration fAILED: ${error.error.error}`);
        }
      );
    } else {
      alert('Please fill all required fields.');
    }
  }

  onLogin() {
    this.router.navigate(['login']);
  }
}
