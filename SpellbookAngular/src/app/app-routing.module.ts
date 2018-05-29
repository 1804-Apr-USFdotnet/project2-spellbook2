import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SpellComponent } from './spell/spell.component';
import { SpellbookComponent } from './spellbook/spellbook.component';

const appRoutes: Routes = [
  {path: 'spells', component: SpellComponent},
  {path: 'spellbook', component: SpellbookComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: []
})
export class AppRoutingModule { }
