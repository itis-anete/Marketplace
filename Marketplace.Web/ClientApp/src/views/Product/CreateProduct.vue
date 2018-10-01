<template>
	<v-container >
		<v-layout row>
			<v-flex xs12 sm6 offset-sm3>
				<v-form ref="form" v-model="valid" lazy-validation>
					<v-text-field
						v-model="name"
						:rules="nameRules"
						label="Название товара"
						required
					></v-text-field>
					
					<v-btn
						:disabled="!valid"
						class="success ml-0"
						@click.prevent="onCreateProduct"
					>
						Создать
					</v-btn>
				</v-form>
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>
export default {
  data() {
    return {
			valid: true,
			nameRules: [
        v => !!v || 'Необходимо указать название товара',
        v => (v && v.length <= 30 ) || 'Название товара не более 30 символов'
			],
			name: ''
    }
	},
	computed: {
	},
	methods: {
    onCreateProduct () {
				const product = {
					Name: this.name,
					Description: this.description
				}
        if (this.$refs.form.validate()) {
					this.$store.dispatch('createProduct', product)
					this.$router.push('/products')
        }
    }
  }
}
</script>