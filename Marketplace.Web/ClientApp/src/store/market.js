import axios from 'axios'

export default {
  state: {
		market: null,
		markets: []
  },
  mutations: {
		setMarkets (state, payload) {
			state.markets = payload
		},
		setMarket (state, payload) {
			state.market = payload
		},
		createMarket (state, payload) {
			state.markets.push(payload)
		}
  },
  actions: {
		async loadMarkets({commit}) {
			commit('setLoading', true)
			try {
				let response = await axios.get('/api/market/getMarkets')
				commit('setMarkets', response.data)
				commit('setLoading', false)
      } catch (err) {
				console.log(err)
				commit('setLoading', false)
      }
		},
		async loadMarket({commit}, payload){
			commit('setLoading', true)
			try{
				let response = await axios.get('/api/Market/GetMarketById/' + payload)
				commit('setMarket', response.data)
				commit('setLoading', false)
			} catch (err) {
				console.log(err)
				commit('setLoading', false)
      }
		},		
		async createMarket({commit}, payload){
			try{
				let response = await axios.post('../api/Market/AddMarket', payload)
				commit('createMarket', response.data)
			} catch (err) {
        console.log(err)
      }
		}
  },
  getters: {
		markets (state) {
			return state.markets
		},
		market (state) {
			return state.market
		}
  }
}