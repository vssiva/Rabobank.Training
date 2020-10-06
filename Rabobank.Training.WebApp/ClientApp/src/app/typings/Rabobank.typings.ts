declare module Rabobank.Training.ClassLibrary.ViewModels {
  interface IMandateViewModel {
    name: string;
    allocation: number;
    value: number;
  }
  interface IPositionViewModel {
    code: string;
    name: string;
    value: number;
    mandates: IMandateViewModel[];
  }
  interface IPortfolioiewModel {
    positions: IPortfolioiewModel[];
  }
}
