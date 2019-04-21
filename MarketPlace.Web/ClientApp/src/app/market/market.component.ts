import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.css']
  
})
export class MarketComponent {
  public markets: EnterData;
  public page: number = 0;
  http: HttpClient;
  baseUrl: string;
  filter: string;
  router: Router;
  public selectedMarket: string = '';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.filter = '';
    this.http = http;
    this.router = router;
    this.baseUrl = baseUrl;
    this.getPage(this.page);
  }

  getFilter(filter: string) {
    this.filter = filter;
    this.getPage(0);
  }

  redirect(name: string) {
    this.selectedMarket = name;
    this.router.navigate(['/market/details', name]);
  }

  getPage(page: number) {
    this.page = page;
    this.http.get<EnterData>(this.baseUrl + 'api/Market/Index?page=' + page + '&filter=' + this.filter).subscribe(result => {
      this.markets = result;
    }, error => console.error(error));
  }
}

interface EnterData {
  name: string[];
  maxPage: number;
}
