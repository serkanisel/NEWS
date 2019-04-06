import { AlertifyService } from './../_services/Alertify.service';
import { AuthService } from './../_services/Auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Alert } from 'selenium-webdriver';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {}

  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('Please log in the site!...');
    this.router.navigate(['/home']);
    return false;
  }
}
