import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-market-details',
  templateUrl: './market.details.component.html',
  styleUrls: ['./market.details.component.css']
})
export class MarketDetailsComponent {
  public market: Market;
  public page: number;
  public marketName: string;
  public sameProducts: SameProduct[];
  http: HttpClient;
  baseUrl: string;
  selectedProduct: Product;
  selectedSameProduct: SameProduct;
  route: ActivatedRoute;
  router: Router;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute, router: Router) {
    this.page = 0;
    this.router = router;
    this.route = route;
    this.http = http;
    this.baseUrl = baseUrl;
    this.getPage(this.page, route.snapshot.params['name']);
  }

  isSelectedProduct(product: Product): boolean {
    if (this.selectedProduct != undefined && product.id == this.selectedProduct.id) {
      return true;
    }
    else {
      return false;
    }
  }

  getPage(page: number, name: string) {
    this.page = page;
    this.marketName = name;
    this.http.get<Market>(this.baseUrl + 'api/Market/Details?page=' + page + '&name=' + name).subscribe(result => {
      this.market = result;
    }, error => console.error(error));
  }
  
  productOnClick(product: Product) {
    this.selectedProduct = product;
    this.selectedSameProduct = null;
    this.http.get<SameProduct[]>(this.baseUrl + 'api/Product/GetSameProducts?id=' + product.id + '&name=' + product.name).subscribe(result => {
      this.sameProducts = result;
    }, error => console.error(error));
  }

  sameProductOnClick(product: SameProduct) {
    this.selectedSameProduct = product;
  }

  goToMarket(name: string) {
    this.selectedProduct = this.selectedSameProduct.product;
    this.selectedSameProduct = null;
    this.router.navigate(['/market/details', name]);
    this.productOnClick(this.selectedProduct);
    this.getPage(0, name);
  }
}

interface SameProduct{
  marketName: string;
  product: Product;
}

interface Market {
  name: string;
  products: Product[];
  categories: Category[];
  maxPage: number;
}

interface Product {
  id: string;
  name: string;
  cost: number;
  description: string;
  categories: Category[];
}

interface Category {
  id: string;
  name: string;
}
