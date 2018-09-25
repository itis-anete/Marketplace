import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
import market from './market'
import product from './product'
import productOffer from './productOffer'
import shared from './shared'

export default new Vuex.Store({
	modules: {
    market: market,
    product: product,
		productOffer: productOffer,
		shared: shared
  }
})
