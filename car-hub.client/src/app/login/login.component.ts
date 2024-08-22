import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CarModelService } from '../services/car-model.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string = "";
  password: string = "";

  constructor(private authService: CarModelService, private router: Router) { }

  ngOnInit(): void {
  }

  login(form: NgForm) {
    if (form.valid) {
      this.authService.login(this.username, this.password).subscribe(
        response => {
          localStorage.setItem('token', response.token);
          localStorage.setItem('isLoggedIn', 'true');
          
          form.resetForm();

          this.router.navigate(['view']);
        },
        error => {
          alert('Login failed');
        }
      );
    }
  }

  onRegister() {
    this.router.navigate(['register']);
  }
}
