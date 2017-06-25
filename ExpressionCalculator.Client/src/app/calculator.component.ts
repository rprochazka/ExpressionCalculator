import { CalculatorService } from './calculator.service';
import {ICalculateResult, ICalculateHistoryResult} from './calculator.model'
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  calculationResult: ICalculateResult;
  errorMessage: string;
  historyResult: ICalculateHistoryResult[];

  constructor(private calculatorService: CalculatorService) {}

  ngOnInit() {}

  calculate(expression: string) {
    this.calculationResult = null
    this.errorMessage = null

    this.calculatorService
      .calculate(expression)
      .subscribe(
        result => {
          if (result.isSuccessfull) {
            this.calculationResult = result
          } else {
            this.errorMessage = result.calculationError.errorText
          }
        },
        error => (this.errorMessage = <any>error)
      );
  }

  showHistory() {
    this.calculatorService
      .showHistory()
      .subscribe(
        result => this.historyResult = result,
        error => (this.errorMessage = <any>error)
      );
  }
}
