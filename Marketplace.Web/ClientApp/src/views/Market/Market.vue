<template>
  <v-container fluid class="pl-0 pb-0 pt-0 pr-0" v-if="market">
		<v-container class="panel" fluid>
			<v-flex xs12 class="text-xs-right">
				<v-btn fab small @click.stop="drawer = !drawer" >
					<v-icon dark>list</v-icon>
				</v-btn>
			</v-flex>
			<v-navigation-drawer
				v-model="drawer"
				absolute
				temporary
				right
			>
				<v-list class="pa-1">
					<v-list-tile avatar>
						<v-list-tile-avatar>
							<v-icon>settings</v-icon>
						</v-list-tile-avatar>
		
						<v-list-tile-content>
							<v-list-tile-title>Панель управления</v-list-tile-title>
						</v-list-tile-content>
					</v-list-tile>
				</v-list>
		
				<v-list class="pt-0" dense>
					<v-divider></v-divider>
					<router-link :to="'/markets/'+market.id+'/createProductOffer'">
						<v-list-tile @click="">
							<v-list-tile-action>
								<v-icon>add</v-icon>
							</v-list-tile-action>
			
							<v-list-tile-content>
								<v-list-tile-title>Добавить товар</v-list-tile-title>
							</v-list-tile-content>
						</v-list-tile>
					</router-link>
					<template><edit-market :market="market"></edit-market></template>
				</v-list>
			</v-navigation-drawer>
		</v-container>
  	<v-container grid-list-xs fluid>
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
			<v-layout row wrap justify-center>
				<v-flex xs12 sm4 v-if="market">
					<v-card>
						<v-card-text class="accent white--text text-xs-center display-2 ">							
							{{market.name}}
						</v-card-text>						
					</v-card>
				</v-flex>		
			</v-layout>		
			<transition-group name="slide" tag="v-layout" class="row wrap mt-5" v-if="market" :key="market.id">
				<v-flex xs12 sm2 v-for="productOffer in market.productOffers" :key="productOffer.id" class="mr-4 mb-4" style="min-width:290px">	
					<router-link :to="'/productOffer/' + productOffer.id">					
						<v-card class="pointer">
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
			</transition-group>	
		</v-container>
  </v-container fluid class="pl-0 pb-0 pt-0 pr-0">
</template>

<script>
	export default {
	props: ['id'],
  data() {
    return {
			drawer: null
    }
	},
	computed: {
		market () {
			return this.$store.getters.market
		},
		loading () {
			return this.$store.getters.loading
		}
	},
	created() {		
		this.$store.dispatch('loadMarket', this.id)
	},
  name: "Market"
}
</script>

<style scoped>
	a {
		text-decoration: none;
		color: rgba(0,0,0,.87)
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
		transition: all 0.5s;
	}
	.pointer:hover {
		cursor: pointer;
		box-shadow: 0px 2px 10px 0px rgba(0,0,0,0.5);		
	}
	.panel {
		box-shadow: inset 0px -2px 0px 0px #039be5, 0px 0px 10px 5px rgba(0,0,0,0.3);
	}
</style>

