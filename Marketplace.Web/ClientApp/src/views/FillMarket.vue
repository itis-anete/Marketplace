<template>
	<v-container >		
		<v-flex xs12 v-if="market">				
			{{market.name}}
		</v-flex>
		<v-layout row>
			<v-flex xs12 sm6 offset-sm3>
				<v-form ref="form" v-model="valid" lazy-validation>
					<v-autocomplete
						v-model="product"
						:items="products"
						:label="`Выберите товар`"
						item-text="name"
						return-object
						:rules="[v => !!v || 'Выберите товар']"
						required
					>						
					</v-autocomplete>
					<v-btn
						:disabled="!valid"
						class="success ml-0"
						@click.prevent="onCreateMarketProduct"
					>
						Добавить
					</v-btn>
				</v-form>
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>
export default {
	props: ['id'],
  data() {
    return {
			valid: true,
      product: null,
    }
	},
	computed: {
		market() {
			return this.$store.getters.loadedMarket
		},
		products () {
			return this.$store.getters.loadedProducts
		}
	},
	methods: {
    onCreateMarketProduct () {
				const marketProduct = {
					MarketId: this.id,
					ProductId: this.product.id
				}
        if (this.$refs.form.validate()) {
					this.$store.dispatch('createMarketProduct', marketProduct)
					this.$router.push('/markets/'+this.id)
        }
    }
	},
	created() {
		if(!this.market)
			this.$store.dispatch('loadMarket', {id: this.id})
			this.$store.dispatch('loadProducts')
	},
}
</script>