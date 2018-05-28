import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './/app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CookieService } from 'angular2-cookie/services/cookies.service';

import { AppComponent } from './app.component';
import { SpellComponent } from './spell/spell.component';
import { SpellFilterComponent } from './spell-filter/spell-filter.component';
import { SpellDetailsComponent } from './spell-details/spell-details.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SpellFormatPipe } from './spell-format.pipe';
import { LoginModalComponent } from './login-modal/login-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    SpellComponent,
    SpellFilterComponent,
    SpellDetailsComponent,
    HeaderComponent,
    FooterComponent,
    SpellFormatPipe,
    LoginModalComponent
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
  providers: [ CookieService ],
  bootstrap: [AppComponent],
  entryComponents: [
    LoginModalComponent
  ]
})
export class AppModule { }
