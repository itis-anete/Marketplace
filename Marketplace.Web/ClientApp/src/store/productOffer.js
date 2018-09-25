import axios from 'axios'

export default {
  state: {				
		productOffer: null,
		competitiveProductOffers: []
  },
  mutations: {		
		setCompetitiveProductOffers (state, payload) {
			state.competitiveProductOffers = payload
		},
		setProductOffer (state, payload) {
			state.productOffer = payload
		}
  },
  actions: {
		async loadProductOffer({commit}, payload){
			try{
				let response = await axios.get('../api/ProductOffer/GetProductOfferById/' + payload)
				commit('setProductOffer', response.data)
			} catch (err) {
        console.log(err)
      }
		},
		async loadCompetitiveProductOffers({commit}, payload){
			try{
				let response = await axios.get('../api/ProductOffer/GetCompetitiveProductsOffers/' + payload)
				commit('setCompetitiveProductOffers', response.data)
			} catch (err) {
        console.log(err)
      }
		},		
		async createProductOffer({commit}, payload){
			try{
				let response = await axios.post('../api/ProductOffer/AddProductOffer', payload)
			} catch (err) {
        console.log(err)
      }
		}
  },
  getters: {		
		competitiveProductOffers (state) {
			return state.competitiveProductOffers
		},
		productOffer (state) {
			return state.productOffer
		}
  }
}