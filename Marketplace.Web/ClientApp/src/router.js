import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Products from './views/Products.vue'
import Markets from './views/Markets.vue'
import Market from './views/Market.vue'
import CreateMarket from './views/CreateMarket.vue'
import CreateProduct from './views/CreateProduct.vue'
import FillMarket from './views/FillMarket.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/products',
      name: 'products',
      component: Products
		},
		{
      path: '/products/new',
      name: 'CreateMarketProduct',
      component: CreateProduct
		},	
    {
      path: '/markets',
      name: 'markets',
      component: Markets
		},
		{
      path: '/markets/new',
      name: 'CreateMarket',
      component: CreateMarket
		},
		{
      path: '/markets/:id/fill',
			name: 'FillMarket',
			props: true,
      component: FillMarket
    },
    {
      path: '/markets/:id',
      name: 'Market',
      props: true,
      component: Market
    },
  ]
})
