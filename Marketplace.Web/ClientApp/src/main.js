import '@babel/polyfill'
import Vue from 'vue'
import axios from 'axios'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'
import store from './store/store'
import EditMarket from './components/EditMarket.vue'
import EditProductOffer from './components/EditProductOffer.vue'
import SideMenu from './components/SideMenu.vue'
import PriceFilter from './filters/price'

Vue.config.productionTip = false

Vue.prototype.$http = axios
Vue.component('edit-market', EditMarket)
Vue.component('edit-productOffer', EditProductOffer)
Vue.component('side-menu', SideMenu)
Vue.filter('price', PriceFilter)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
