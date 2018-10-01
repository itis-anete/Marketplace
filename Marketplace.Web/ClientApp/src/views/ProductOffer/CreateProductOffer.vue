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
					<v-text-field
						v-model="price"
						type="number"
						label="Стоимость товара"
						:rules="[v => !!v || 'Укажите стоимость товара']"
						required
					></v-text-field>
					<v-text-field
						v-model="description"
						label="Описание товара"
						:rules="descriptionRules"
						required
					></v-text-field>
					<v-text-field
						v-model="image"
						label="Изображение товара"
						:rules="[v => !!v || 'Укажите ссылку на изображение товара']"
						required
					></v-text-field>
					<img :src="image" v-if="image" height="200px"> <br>
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
			price: null,			
			descriptionRules: [
        v => !!v || 'Необходимо указать описание товара',
        v => (v && v.length <= 1000 ) || 'Описание товара не более 1000 символов'
			],
			description: '',
			image: ''
    }
	},
	computed: {
		market() {
			return this.$store.getters.market
		},
		products () {
			return this.$store.getters.products
		}
	},
	methods: {
    onCreateMarketProduct () {
			const productOffer = {
				MarketId: this.id,
				ProductId: this.product.id,
				Price: this.price,
				Description: this.description,
				Image: this.image
			}
			if (this.$refs.form.validate()) {
				this.$store.dispatch('createProductOffer', productOffer)
				this.$router.push('/markets/' + this.id)
			}
    }
	},
	created() {
		if(!this.market)
			this.$store.dispatch('loadMarket', this.id)
			this.$store.dispatch('loadProducts')
	},
}
</script>