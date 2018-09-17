import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
		loadedProducts: [],
		loadedMarkets: []
  },
  mutations: {
		setLoadedProducts (state, payload) {
			state.loadedProducts = payload
		},
		setLoadedMarkets (state, payload) {
			state.loadedMarkets = payload
		}
  },
  actions: {
		async loadProducts({commit}) {
			try {
				let response = await axios.get('/api/product/getProducts')
				commit('setLoadedProducts', response.data)
      } catch (err) {
        console.log(err)
      }
		},
		async loadMarkets({commit}) {
			try {
				let response = await axios.get('/api/market/getMarkets')
				commit('setLoadedMarkets', response.data)
      } catch (err) {
        console.log(err)
      }
		}
	},
	getters: {
		loadedProducts (state) {
			return state.loadedProducts
		},
		loadedMarkets (state) {
			return state.loadedMarkets
		}
	}
})
