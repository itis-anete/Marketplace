<template>
	<v-container >
		<v-layout row>
			<v-flex xs12 sm6 offset-sm3>
				<v-form ref="form" v-model="valid" lazy-validation>
					<v-text-field
						v-model="name"
						:rules="nameRules"
						label="Название магазина"
						required
					></v-text-field>
					<v-btn
						:disabled="!valid"
						class="success ml-0"
						@click.prevent="onCreateMarket"
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
        v => !!v || 'Необходимо указать название магазина',
        v => (v && v.length <= 15 ) || 'Название магазина не более 15 символов'
      ],
      name: '',
    }
	},
	computed: {
	},
	methods: {
    onCreateMarket () {
				const market = {
					Name: this.name
				}
        if (this.$refs.form.validate()) {
					this.$store.dispatch('createMarket', market)
					this.$router.push('/markets')
        }
    }
  }
}
</script>