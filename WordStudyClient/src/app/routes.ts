import { MemberEditResolver } from './_resolver/member-edit.resolver';
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
      { path: 'members/:id', component: MemberDetailComponent , resolve: {user: MemberDetailResolver}  },
      { path: 'member/edit', component: MemberEditComponent, resolve: { user:MemberEditResolver}} ,
      { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
      { path: 'messages', component: MessagesComponent},
      { path: 'lists', component: ListsComponent}
    ]
  },
  { path: '**' , redirectTo: '', pathMatch: 'full'},
];

