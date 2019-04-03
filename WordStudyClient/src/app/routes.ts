import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WordsComponent } from './words/words.component';
import { WordlistsComponent } from './wordlists/wordlists.component';
import { GamesComponent } from './games/games.component';
import { ReadingpartsComponent } from './readingparts/readingparts.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'words', component: WordsComponent},
  { path: 'wordlists', component: WordlistsComponent},
  { path: 'games', component: GamesComponent},
  { path: 'readingparts', component: ReadingpartsComponent},
  { path: '**' , redirectTo: 'home', pathMatch: 'full'},
];

