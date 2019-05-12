import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { WrdList } from '../_models/WrdList';
import { WrdlistService } from '../_services/wrdlist.service';
import { AlertifyService } from '../_services/Alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class WrdListResolver implements Resolve<WrdList[]> {
    constructor(private wrdListService: WrdlistService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<WrdList[]> {
        return this.wrdListService.getWrdLists().pipe(
            catchError( errror => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/wordlists']);
                return of(null);
            })
        );
    }
}
