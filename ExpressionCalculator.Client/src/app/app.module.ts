import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http'

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
    HttpModule
  ],
  providers: [CalculatorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
