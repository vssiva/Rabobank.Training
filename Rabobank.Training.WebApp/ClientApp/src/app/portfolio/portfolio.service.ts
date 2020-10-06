import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  private baseUrl = "";
  constructor(private httpService: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  getPortfolio(): Observable<Rabobank.Training.ClassLibrary.ViewModels.IPortfolioiewModel> {
    const url = this.baseUrl + 'GetPortfolio';
    return this.httpService.get<Rabobank.Training.ClassLibrary.ViewModels.IPortfolioiewModel>(url);
  }
}
