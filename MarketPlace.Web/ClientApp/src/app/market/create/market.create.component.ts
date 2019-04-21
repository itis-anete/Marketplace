import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-market-create',
  templateUrl: './market.create.component.html',
  styleUrls: ['./market.create.component.css']
})
export class MarketCreateComponent {
  baseUrl: string;
  router: Router;
  complete: boolean;
  market: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.baseUrl = baseUrl;
    this.router = router;
    this.complete = false;
  }

  postData(market: string) {
    this.market = market;
    const body = { market: market };
    this.http.post<boolean>(this.baseUrl + 'api/Market/Create', body).subscribe(result => { this.complete = result });
    this.router.navigate['/market'];
  }

  redirect(name: string) {
    this.router.navigate(['/market/details', name]);
  }
}
