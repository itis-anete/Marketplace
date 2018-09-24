import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
		loadedProducts: [],
		loadedMarkets: [],
		loadedMarketProducts: [],
		loadedMarket: null
  },
  mutations: {
		setLoadedProducts (state, payload) {
			state.loadedProducts = payload
		},
		setLoadedMarkets (state, payload) {
			state.loadedMarkets = payload
		},
		setLoadedMarket (state, payload) {
			state.loadedMarket = payload
		},
		createMarket (state, payload) {
			state.loadedMarkets.push(payload)
		},
		createProduct (state, payload) {
			state.loadedProducts.push(payload)
		},
		setLoadedMarketProducts (state, payload) {
			state.loadedMarketProducts = payload
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
		},
		async loadMarket({commit}, payload){
			try{
				let response = await axios.get('/api/Market/GetMarket/' + payload.id)
				commit('setLoadedMarket', response.data)
			} catch (err) {
        console.log(err)
      }
		},
		async loadMarketProducts({commit}, payload){
			try{
				let response = await axios.get('../api/MarketProduct/GetMarketProduct/' + payload.id)
				commit('setLoadedMarketProducts', response.data)
			} catch (err) {
        console.log(err)
      }
		},
		async createMarket({commit}, payload){
			try{
				let response = await axios.post('../api/Market/AddMarket/', payload)
				commit('createMarket', response.data)
			} catch (err) {
        console.log(err)
      }
		},
		async createProduct({commit}, payload){
			try{
				let response = await axios.post('../api/Product/AddProduct/', payload)
				commit('createProduct', response.data)
			} catch (err) {
        console.log(err)
      }
		},
		async createMarketProduct({commit}, payload){
			try{
				let response = await axios.post('../api/MarketProduct/AddMarketProduct/', payload)
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
		},
		loadedMarket (state) {
			return state.loadedMarket
		},
		loadedMarketProducts (state) {
      return state.loadedMarketProducts
    }
	}
})
