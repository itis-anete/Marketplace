import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

import Products from './views/Product/Products.vue'
import CreateProduct from './views/Product/CreateProduct.vue'

import Markets from './views/Market/Markets.vue'
import Market from './views/Market/Market.vue'
import CreateMarket from './views/Market/CreateMarket.vue'

import CreateProductOffer from './views/ProductOffer/CreateProductOffer.vue'
import ProductOffer from './views/ProductOffer/ProductOffer.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/products',
      name: 'Products',
      component: Products
		},
		{
      path: '/products/new',
      name: 'CreateProduct',
      component: CreateProduct
		},
    {
      path: '/markets',
      name: 'Markets',
      component: Markets
		},		
    {
      path: '/markets/:id',
      name: 'Market',
      props: true,
      component: Market
    },
		{
      path: '/market/new',
      name: 'CreateMarket',
      component: CreateMarket
		},
		{
      path: '/productOffer/:id',
      name: 'ProductPffer',
			component: ProductOffer,
			props: true
		},
		{
      path: '/markets/:id/createProductOffer',
			name: 'CreateProductOffer',
			props: true,
      component: CreateProductOffer
    }
  ]
})
