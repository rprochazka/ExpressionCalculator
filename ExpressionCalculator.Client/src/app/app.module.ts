import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http'
import 'hammerjs'
import { MaterialModule } from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MdButtonModule, MdInputModule, MdCardModule, MdSlideToggleModule} from '@angular/material';

import { AppComponent } from './app.component';
import {CalculatorService} from './calculator.service';
import { CalculatorComponent } from './calculator.component';

@NgModule({
  declarations: [
    AppComponent,
    CalculatorComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    MaterialModule,
    BrowserAnimationsModule,
    MdInputModule,
    MdButtonModule,
    MdCardModule,
    MdSlideToggleModule
  ],
  providers: [CalculatorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
