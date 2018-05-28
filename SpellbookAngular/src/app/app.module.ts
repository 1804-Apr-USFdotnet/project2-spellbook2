import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { RouterModule, Routes, PreloadAllModules } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './/app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { SpellComponent } from './spell/spell.component';
import { SpellFilterComponent } from './spell-filter/spell-filter.component';
import { SpellDetailsComponent } from './spell-details/spell-details.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    SpellComponent,
    SpellFilterComponent,
    SpellDetailsComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
