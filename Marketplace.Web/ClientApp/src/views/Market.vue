<template>
  <v-container grid-list-xs>
		<v-layout row wrap>
			<v-flex xs12 v-if="market">				
			{{market.name}}
			</v-flex>
			<v-flex xs12>
				<v-btn :to="'/markets/'+market.id+'/fill'">Добавить товар</v-btn>
			</v-flex>			
		</v-layout>
		<transition-group name="slide" tag="v-layout" class="row wrap justify-center">
			<v-flex xs12 sm2 v-for="marketProduct in market.products" :key="marketProduct.id" class="mr-4 mb-4" style="min-width:290px">		
						<v-card :key="marketProduct.id">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{marketProduct.product.name}}
							</v-card-title>
							<v-card-text>
								<v-icon class="mr-1 accent--text">attach_money</v-icon> {{marketProduct.product.cost}}
							</v-card-text>
						</v-card>
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
		market () {
			return this.$store.getters.loadedMarket
		},
	},
	methods: {
	},
	created() {		
		this.$store.dispatch('loadMarket', {id: this.id})
	},
  name: "Market"
}
</script>

<style scoped>
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
</style>

