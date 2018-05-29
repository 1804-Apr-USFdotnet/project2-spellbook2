import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './/app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { SpellComponent } from './spell/spell.component';
import { SpellFilterComponent } from './spell-filter/spell-filter.component';
import { SpellDetailsComponent } from './spell-details/spell-details.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SpellFormatPipe } from './spell-format.pipe';
import { SpellbookComponent } from './spellbook/spellbook.component';
import { LoginModalComponent } from './login-modal/login-modal.component';
import { CreateUserModalComponent } from './create-user-modal/create-user-modal.component';
import { CharactersComponent } from './characters/characters.component';

@NgModule({
  declarations: [
    AppComponent,
    SpellComponent,
    SpellFilterComponent,
    SpellDetailsComponent,
    HeaderComponent,
    FooterComponent,
    SpellFormatPipe,
    LoginModalComponent,
    CreateUserModalComponent,
    SpellbookComponent,
    CharactersComponent
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [ ],
  bootstrap: [AppComponent],
  entryComponents: [
    LoginModalComponent,
    CreateUserModalComponent
  ]
})
export class AppModule { }
