import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import {AlertifyService} from '../_services/Alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertifyService: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(() => {
      this.alertifyService.success('Wellcome our site!....');
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
  }
}
