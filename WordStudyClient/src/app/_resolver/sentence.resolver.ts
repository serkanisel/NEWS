import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/Alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SentenceService } from '../_services/sentence.service';
import { Sentence } from '../_models/sentence';

@Injectable()
export class SentenceResolver implements Resolve<Sentence[]> {
    constructor(private sentenceService: SentenceService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Sentence[]> {
        return this.sentenceService.getSentences().pipe(
            catchError( errror => {
                this.alertify.error('Problem retrieving sentences');
                this.router.navigate(['/sentences']);
                return of(null);
            })
        );
    }
}
