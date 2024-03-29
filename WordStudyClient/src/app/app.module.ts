import { UserService } from './_services/user.service';
import { AlertifyService } from './_services/Alertify.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/Auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { WordsComponent } from './words/words.component';
import { GamesComponent } from './games/games.component';
import { ReadingpartsComponent } from './readingparts/readingparts.component';
import { WordlistsComponent } from './wordlists/wordlists.component';
import { appRoutes } from './routes';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberDetailResolver } from './_resolver/member-detail.resolver';
import { MemberListResolver } from './_resolver/member-list.resolver';
import { MemberEditResolver } from './_resolver/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-change.guard';
import { WordCardComponent } from './word-card/word-card.component';
import { WordResolver } from './_resolver/word.resolver';
import { WrdListResolver } from './_resolver/wrdList.resolver';
import { SentenceComponent } from './sentence/sentence.component';
import { SentenceResolver } from './_resolver/sentence.resolver';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      WordsComponent,
      GamesComponent,
      ReadingpartsComponent,
      WordlistsComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
      MemberCardComponent,
      MemberDetailComponent,
      MemberEditComponent,
      WordCardComponent,
      SentenceComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:500/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      AlertifyService,
      ErrorInterceptorProvider,
      UserService,
      MemberDetailResolver,
      MemberListResolver,
      MemberEditResolver,
      PreventUnsavedChanges,
      WordResolver,
      WrdListResolver,
      SentenceResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
