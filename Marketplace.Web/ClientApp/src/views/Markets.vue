<template>
  <v-container grid-list-xs>
		<transition-group name="slide" tag="v-layout" class="row wrap justify-center">
			<v-flex xs12 sm2 v-for="market in markets" :key="market.id" class="mr-4 mb-4" style="min-width:290px">		
						<v-card :key="market.id">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{market.name}}
							</v-card-title>
						</v-card>				
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
			return this.$store.getters.loadedMarkets
		},
	},
	methods: {		
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
</style>

