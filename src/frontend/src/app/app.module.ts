import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MaterialModule} from './material.module';
import {ShowComponent} from './components/show/show.component';
import {CreateComponent} from './components/create/create.component';
import {MoveComponent} from './components/move/move.component';
import {RemoveComponent} from './components/remove/remove.component';
import {AppService} from './app.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {OpenComponent} from './components/open/open.component';
import {BaseComponent} from './components/base/base.component';

@NgModule({
  declarations: [
    AppComponent, ShowComponent, CreateComponent, MoveComponent, RemoveComponent, OpenComponent, BaseComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
