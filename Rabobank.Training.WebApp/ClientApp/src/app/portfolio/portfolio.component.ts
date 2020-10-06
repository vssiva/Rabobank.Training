import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PortfolioService } from './portfolio.service'
@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html'
})
export class PortfolioComponent {
  public portfolioViewModel: Rabobank.Training.ClassLibrary.ViewModels.IPortfolioiewModel;
  constructor(private portfolioService: PortfolioService) {
    this.loadPortfolio();
  }
  public loadPortfolio() {
    this.portfolioService.getPortfolio().subscribe(result => {
      this.portfolioViewModel = result;
    },
      error => { })
  }
}
