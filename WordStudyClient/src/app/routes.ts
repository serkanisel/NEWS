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
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolver/member-detail.resolver';
import { MemberListResolver } from './_resolver/member-list.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-change.guard';
import { WordResolver } from './_resolver/word.resolver';
import { WrdListResolver } from './_resolver/wrdList.resolver';
import { SentenceComponent } from './sentence/sentence.component';
import { SentenceResolver } from './_resolver/sentence.resolver';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'words', component: WordsComponent, resolve: {words: WordResolver}},
      { path: 'wordlists', component: WordlistsComponent, resolve: {wrdlists: WrdListResolver}},
      { path: 'sentences', component: SentenceComponent, resolve: {sentences: SentenceResolver}},
      { path: 'games', component: GamesComponent},
      { path: 'readingparts', component: ReadingpartsComponent},
      { path: 'members/:id', component: MemberDetailComponent , resolve: {user: MemberDetailResolver}  },
      { path: 'member/edit', component: MemberEditComponent, resolve: { user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]} ,
      { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
      { path: 'messages', component: MessagesComponent},
    ]
  },
  { path: '**' , redirectTo: '', pathMatch: 'full'},
];

