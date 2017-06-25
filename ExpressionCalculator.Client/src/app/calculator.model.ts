export interface ICalculateResult {
  result: number;
  isSuccessfull: boolean;
  calculationError?: {
    errorText: string,
    indexes?: Array<number>
  }
}

export interface ICalculateHistoryResult {
  expression: string;
  dateGenerated: string;
  calculationResult: ICalculateResult;
}
