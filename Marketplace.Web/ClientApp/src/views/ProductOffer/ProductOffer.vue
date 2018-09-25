<template>
  <v-container grid-list-xs>
		<v-layout row wrap v-if="productOffer">
			<v-flex xs12>
				{{productOffer.market.name}}
				{{productOffer.product.name}}
				{{productOffer.price}}
			</v-flex>
		</v-layout>
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
		<transition-group name="slide" tag="v-layout" class="row wrap justify-center" v-if="competitiveProductOffers">
			<v-flex xs12 sm2 v-for="productOffer in competitiveProductOffers" :key="productOffer.id" class="mr-4 mb-4" style="min-width:290px">		
				<router-link :to="'/productOffer/' + productOffer.id">
					<v-hover>
						<v-card :key="productOffer.id" slot-scope="{ hover }" :class="`elevation-${hover ? 8 : 0}`" class="mx-auto pointer">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{productOffer.market.name}}
							</v-card-title>
							<v-card-text>
								<v-icon class="mr-1 accent--text">attach_money</v-icon> {{productOffer.price}}
							</v-card-text>
						</v-card>
					</v-hover>
				</router-link>
				
			</v-flex>
		</transition-group>
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
  name: "ProductOffer"
}
</script>

<style scoped>
	a {
		text-decoration: none;
	}

	.slide-enter {
			transform: translateY(100px);
			opacity: 0;
	}

	.slide-enter-active {
			transition: all 1s ease-out;
	}

	.slide-leave-active {
			position: absolute;
	}

	.slide-leave-to {
			transform: translateY(1000px);
			opacity: 0;
	}

	.slide-move {
			transition: all 1s;
	}

	.pointer {
		cursor: pointer;
	}
</style>

