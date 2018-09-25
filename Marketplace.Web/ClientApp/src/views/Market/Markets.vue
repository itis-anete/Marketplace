<template>
  <v-container grid-list-xs>
		<v-btn :to="'/market/new'">Создать</v-btn>
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
			<v-flex xs12 sm2 v-for="market in markets" :key="market.id" class="mr-4 mb-4" style="min-width:290px" v-if="markets">
				<router-link :to="'/markets/' + market.id">
					<v-hover>	
						<v-card :key="market.id" slot-scope="{ hover }" :class="`elevation-${hover ? 8 : 0}`" class="mx-auto pointer">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{market.name}}
							</v-card-title>					
						</v-card>						
					</v-hover>	
				</router-link>						
			</v-flex>			
		</transition-group>	
	</v-container>
</template>

<script>
	export default {
  data() {
    return {
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
		cursor: pointer;
	}
</style>

