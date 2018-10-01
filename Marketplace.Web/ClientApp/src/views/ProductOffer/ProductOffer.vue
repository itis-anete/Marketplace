<template>
  <v-container grid-list-xs>
		<v-flex xs12 
			class="text-xs-center pt-2 pb-2" 
			v-if="loading"
		> 
			<v-progress-circular
				indeterminate
				color="primary"
				:width="7"
				:size="70"
			></v-progress-circular>
		</v-flex>
		<v-layout row wrap v-if="productOffer" justify-center>
			<v-flex xs12 sm6 md12 lg6 >
				<v-flex xs12>
					<v-layout>
						<span class="display-2">{{productOffer.product.name}}</span>					
						<v-spacer></v-spacer>
						<template>							
							<template><edit-productOffer :productOffer="productOffer"></edit-productOffer></template>
							<v-btn small color="error" @click="deleteProductOffer(productOffer.id)" ><v-icon>close</v-icon></v-btn>
						</template>
					</v-layout>
				</v-flex>
				<v-card class="mt-2">					
					<v-divider class="accent"></v-divider>	
					<v-layout row wrap class="mt-4 pt-4 pb-4">	
						<v-flex xs12 md6>
							<img :src="productOffer.image" :alt="productOffer.product.name" class="product-img">
						</v-flex>
						<v-flex xs12 md4>
							<v-card-text class="display-2">
								<span class="accent--text">{{productOffer.price | price}} </span><span class="headline">руб.</span>
							</v-card-text>
							<v-divider></v-divider>
							<v-card-text class="subheading">									
								 	Магазин: <router-link :to="'/markets/' + productOffer.market.id"><span class="accent-text headline">{{productOffer.market.name}}</span></router-link>
							</v-card-text>	
							<v-divider></v-divider>
							<v-card-text class="subheading">
								{{productOffer.description}}
							</v-card-text>											
						</v-flex>
					</v-layout>
				</v-card>
			</v-flex>
		</v-layout>		
		<v-container grid-list-xl>
			<v-layout row wrap v-if="competitiveProductOffers" class="mt-5">	
				<v-flex xs12>					
					<span class="headline">Товар в других магазинах:</span> <br>
				</v-flex>			
				<v-flex xs12 sm2 v-for="productOffer in competitiveProductOffers" :key="productOffer.id" style="min-width:290px">		
					<router-link :to="'/productOffer/' + productOffer.id">
						<v-card class="pointer">
							<router-link :to="'/markets/' + productOffer.market.id">	
								<v-card-text>
									<p class="text-xs-center mb-0 title accent--text">{{productOffer.market.name}}</p>
								</v-card-text>
							</router-link>
							<v-divider class="accent"></v-divider>											
							<v-card-text class="text-xs-center">
								<img :src="productOffer.image" height="200px">
							</v-card-text>
							<v-card-text class="headline pb-0">
								{{productOffer.product.name}}
							</v-card-text>				
							<v-card-text class="display-1 pt-0 mt-0">
								<span class="accent--text">{{productOffer.price | price}} </span><span class="headline">руб.</span>
							</v-card-text>
						</v-card>
					</router-link>				
				</v-flex>
			</v-layout>
		</v-container>
	</v-container>	
</template>

<script>
	export default {
	props: ['id'],
  data() {
    return {
    }
	},
	computed: {
		productOffer() {
			return this.$store.getters.productOffer
		},
		loading () {
			return this.$store.getters.loading
		},
		competitiveProductOffers() {
			return this.$store.getters.competitiveProductOffers
		}
	},
	created() {
		this.$store.dispatch('loadProductOffer', this.id)
		this.$store.dispatch('loadCompetitiveProductOffers', this.id)
	},
	beforeRouteUpdate (to, from, next) {
		this.$store.dispatch('loadProductOffer', to.params.id)
		this.$store.dispatch('loadCompetitiveProductOffers', to.params.id)
		next()
	},
	methods: {
		deleteProductOffer (id) {
			this.$store.dispatch('deleteProductOffer', id)
			this.$router.push('/markets/'+this.productOffer.market.id)
		}
	},
  name: "ProductOffer"
}
</script>

<style scoped>
	.product-img {
		width: 100%;
	}
	a {
		text-decoration: none;
		color: #039be5
	}
	.pointer {
			transition: all 0.5s;
	}
	.pointer:hover {
		cursor: pointer;
		box-shadow: 0px 2px 10px 0px rgba(0,0,0,0.5);		
	}
</style>

