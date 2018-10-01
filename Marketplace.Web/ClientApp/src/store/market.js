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
		},
		deleteMarket (state, payload) {
			state.markets.splice(state.markets.findIndex(x=>x.id === payload), 1)
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
		},
		async deleteMarket({commit}, payload){
			try{
				let response = await axios.delete('../api/Market/DeleteMarket/' + payload)
				commit('deleteMarket', response.data.id)
			}
			catch (error) {
				console.log(error)				
			}
		},
		async editMarket({commit}, payload) {
			try{
				let response = await axios.put('../api/Market/UpdateMarket', payload)
				commit('setMarket', response.data)
			}
			catch (error) {
				console.log(error)				
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