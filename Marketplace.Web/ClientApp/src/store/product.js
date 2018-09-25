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
		}
  },
  actions: {
		async loadProducts({commit}) {
			try {
				let response = await axios.get('/api/product/getProducts')
				commit('setProducts', response.data)
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
		}
  },
  getters: {
		products (state) {
			return state.products
		}
  }
}