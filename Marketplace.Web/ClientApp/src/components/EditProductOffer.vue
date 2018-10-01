<template>
  <v-dialog width="500px" v-model="editDialog">
    <v-btn small slot="activator">
      <v-icon>edit</v-icon>
    </v-btn>
    <v-card>
      <v-container>
        <v-layout row wrap>
          <v-flex xs12>
            <v-card-title class="pr-0 pl-0">
							Редактирование			
						</v-card-title>
          </v-flex>
        </v-layout>
        <v-divider></v-divider>
        <v-layout row wrap class="mt-4">
          <v-flex xs12>
						<v-form ref="form" v-model="valid" lazy-validation>
							<v-text-field
								v-model="price"
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
							<img :src="image" v-if="image" height="150px"> <br>
							<v-card-actions class="pr-0">
								<v-spacer></v-spacer>
								<v-btn                
									class="error--text"
									@click="editDialog = false">Закрыть</v-btn>
								<v-btn class="success--text ml-4 " @click="onSaveChanges" :disabled="!valid">Сохранить</v-btn>
							</v-card-actions>							
						</v-form>
          </v-flex>
        </v-layout>        
      </v-container>
    </v-card>
  </v-dialog>
</template>

<script>
	export default {
    props: ['productOffer'],
    data () {
      return {
				editDialog: false,
				valid: true,
				price: this.productOffer.price,
				descriptionRules: [
					v => !!v || 'Необходимо указать описание товара',
					v => (v && v.length <= 1000 ) || 'Описание товара не более 1000 символов'
				],
				description: this.productOffer.description,
				image: this.productOffer.image
      }
    },
    methods: {
      onSaveChanges () {
        if (this.$refs.form.validate()) {
					this.editDialog = false
					this.$store.dispatch('editProductOffer', {
						Id: this.productOffer.id,
						Price: this.price,
						Description: this.description,
						Image: this.image
					})
				}        
			}
    }
  }
</script>
