import { CalculatorService, ICalculateResult } from './calculator.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  successResult: ICalculateResult;
  errorMessage: string;

  constructor(private calculatorService: CalculatorService) {}

  ngOnInit() {}

  calculate(expression: string) {
    console.log('Calculate triggered with ' + expression);
    this.successResult = null
    this.errorMessage = null

    this.calculatorService
      .calculate(expression)
      .subscribe(
        result => {
          if (result.isSuccessfull) {
            this.successResult = result
          } else {
            this.errorMessage = result.calculationError.errorText
          }
        },
        error => (this.errorMessage = <any>error)
      );
  }
}
