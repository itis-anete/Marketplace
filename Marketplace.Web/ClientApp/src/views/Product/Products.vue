<template>
  <v-container grid-list-xs>
		<v-btn :to="'/products/new'">Создать</v-btn>
		<transition-group name="slide" tag="v-layout" class="row wrap justify-center">
			<v-flex xs12 sm2 v-for="product in products" :key="product.id" class="mr-4 mb-4" style="min-width:290px">
						<v-card :key="product.id">
							<v-card-title primary-title class="accent white--text" style="min-height: 70px">
								{{product.name}}
							</v-card-title>
							<v-card-text>
								<v-icon class="mr-1 accent--text">attach_money</v-icon> {{product.description}}
							</v-card-text>
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
		products () {
			return this.$store.getters.products
		}
	},
	created () {
		this.$store.dispatch('loadProducts')
	},
  name: "Products"
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

