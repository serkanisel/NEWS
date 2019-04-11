import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import {AlertifyService} from '../_services/Alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertifyService: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(() => {
      this.alertifyService.success('Wellcome our site!....');
      this.router.navigate(['/members']);
    },
    error => {
      // console.log(error);
      // this.alertifyService.error(""");
      this.alertifyService.error('Kullanıcı adı ve/veya şifre hatalı');
    });
  }

  loggedIn() {
   return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertifyService.message('Good bye. Come again please.');
    this.router.navigate(['/home']);
  }
}
