import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Word } from '../_models/word';
import { WordService } from '../_services/word.service';
import { AlertifyService } from '../_services/Alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class WordResolver implements Resolve<Word[]> {
    constructor(private wordService: WordService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Word[]> {
        return this.wordService.getWords().pipe(
            catchError( errror => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/word']);
                return of(null);
            })
        );
    }
}
