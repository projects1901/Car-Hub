import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn = false;
  constructor(private router: Router) { }

  ngOnInit(): void {

    this.isLoggedIn = Boolean(localStorage.getItem("isLoggedIn"));
  }

  logOut() {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  view() {
    this.router.navigate(['view']);
  }
  create() {
    this.router.navigate(['create']);
  }

}
