<template>
  <v-container fluid class="pl-0 pb-0 pt-0 pr-0">		
		<side-menu :items="this.items"></side-menu>
  	<v-container grid-list-xl fluid>		
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
			<transition-group name="slide" tag="v-layout" class="row wrap justify-center">
				<v-flex xs12 sm2 v-for="market in markets" :key="market.id" style="min-width:290px" v-if="markets">
					<router-link :to="'/markets/' + market.id">	
						<v-card :key="market.id" class="pointer">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{market.name}}
								<v-spacer></v-spacer>
								<v-btn flat icon color="white" @click.prevent="deleteMarket(market.id)"><v-icon>delete</v-icon></v-btn>
							</v-card-title>					
						</v-card>
					</router-link>						
				</v-flex>			
			</transition-group>	
		</v-container>
  </v-container>
</template>

<script>
	export default {
  data() {
    return {
			items: [
				{ title: 'Создать магазин', icon: 'add', path: '/market/new' }
      ]
    }
	},
	computed: {
		markets () {
			return this.$store.getters.markets
		},
		loading () {
			return this.$store.getters.loading
		}
	},
	methods: {
		deleteMarket (id) {
			this.$store.dispatch('deleteMarket', id)
		}
	},
	created () {
		this.$store.dispatch('loadMarkets')
	},
  name: "Markets"
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
	.pointer {
			transition: all 0.5s;
	}
	.pointer:hover {
		cursor: pointer;
		box-shadow: 0px 2px 10px 0px rgba(0,0,0,0.5);		
	}
</style>

