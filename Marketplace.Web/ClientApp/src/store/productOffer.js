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
				commit('setLoading', true)
				let response = await axios.get('../api/ProductOffer/GetProductOfferById/' + payload)
				commit('setProductOffer', response.data)
				commit('setLoading', false)
			} catch (err) {
				console.log(err)
				commit('setLoading', false)
      }
		},
		async loadCompetitiveProductOffers({commit}, payload){
			try{
				commit('setLoading', true)
				let response = await axios.get('../api/ProductOffer/GetCompetitiveProductsOffers/' + payload)
				commit('setCompetitiveProductOffers', response.data)
				commit('setLoading', false)
			} catch (err) {
				console.log(err)
				commit('setLoading', false)
      }
		},
		async createProductOffer({commit}, payload){
			try{
				let response = await axios.post('../api/ProductOffer/AddProductOffer', payload)
			} catch (err) {
        console.log(err)
      }
		},
		async deleteProductOffer({commit}, payload){
			try{
				let response = await axios.delete('../api/ProductOffer/DeleteProductOffer/' + payload)
			}
			catch (error) {
				console.log(error)				
			}
		},
		async editProductOffer({commit}, payload) {
			try{
				let response = await axios.put('../api/ProductOffer/UpdateProductOffer', payload)
				commit('setProductOffer', response.data)
			}
			catch (error) {
				console.log(error)				
			}
		}
  },
  getters: {		
		competitiveProductOffers (state) {
			return state.competitiveProductOffers.sort((x,y) => {
				return x.price > y.price
			})
		},
		productOffer (state) {
			return state.productOffer
		}
  }
}