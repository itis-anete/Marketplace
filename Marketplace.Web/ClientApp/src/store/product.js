import axios from 'axios'

export default {
  state: {
		products: [],
  },
  mutations: {
		setProducts (state, payload) {
			state.products = payload
		},
		createProduct (state, payload) {
			state.products.push(payload)
		},
		deleteProduct (state, payload) {
			state.products.splice(state.products.findIndex(x=>x.id === payload), 1)
		}
  },
  actions: {
		async loadProducts({commit}) {
			try {
				commit('setLoading', true)
				let response = await axios.get('/api/product/getProducts')
				commit('setProducts', response.data)
				commit('setLoading', false)
      } catch (err) {
				console.log(err)
				commit('setLoading', false)
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
		async deleteProduct({commit}, payload){
			try{
				let response = await axios.delete('../api/Product/DeleteProduct/' + payload)
				commit('deleteProduct', response.data.id)
			}
			catch (error) {
				console.log(error)				
			}
		}
  },
  getters: {
		products (state) {
			return state.products
		}
  }
}