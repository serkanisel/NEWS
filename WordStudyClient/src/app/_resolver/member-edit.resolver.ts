import {Injectable} from '@angular/core';
import {User} from '../_models/user';
import { UserService } from '../_services/user.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from '../_services/Alertify.service';
import { AuthService } from './../_services/Auth.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberEditResolver implements Resolve<User> {
    constructor(private userService: UserService,
      private authService: AuthService,
      private router: Router,
      private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        console.log('dana veli was here');
        return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
            catchError( errror => {
                this.alertify.error('Problem retrieving your data');
                this.router.navigate(['/members']);
                return of(null);
            })
        );
    }
}
