import { UserService } from './_services/user.service';
import { AlertifyService } from './_services/Alertify.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

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
      MemberCardComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      AlertifyService,
      ErrorInterceptorProvider,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
