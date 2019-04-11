import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WordsComponent } from './words/words.component';
import { WordlistsComponent } from './wordlists/wordlists.component';
import { GamesComponent } from './games/games.component';
import { ReadingpartsComponent } from './readingparts/readingparts.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolver/member-detail.resolver';
import { MemberListResolver } from './_resolver/member-list.resolver';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'words', component: WordsComponent},
      { path: 'wordlists', component: WordlistsComponent},
      { path: 'games', component: GamesComponent},
      { path: 'readingparts', component: ReadingpartsComponent},
<<<<<<< HEAD
      { path: 'members/:id', component: MemberDetailComponent , canActivate:  [AuthGuard]},
      { path: 'member/edit', component: MemberEditComponent },
      { path: 'members', component: MemberListComponent , canActivate:  [AuthGuard]},
=======
      { path: 'members/:id', component: MemberDetailComponent , resolve: {user: MemberDetailResolver}  },
      { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
>>>>>>> 9e11821694a67fb727e8fcd70ecde541cb7efbd4
      { path: 'messages', component: MessagesComponent},
      { path: 'lists', component: ListsComponent}
    ]
  },
  { path: '**' , redirectTo: '', pathMatch: 'full'},
];

