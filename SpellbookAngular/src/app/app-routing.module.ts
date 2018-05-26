import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { SpellComponent } from './spell/spell.component';

const appRoutes: Routes = [
  {path: "spells", component: SpellComponent},
  {path: '', loadChildren: "./app/app.module#AppModule", data: {preload: true}}
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules})
  ],
  declarations: []
})
export class AppRoutingModule { }
