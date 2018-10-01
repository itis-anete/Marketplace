<template>
  <v-dialog width="500px" v-model="editDialog" style="display:block">
    <v-list-tile @click="" slot="activator">
			<v-list-tile-action>
				<v-icon>edit</v-icon>
			</v-list-tile-action>
	
			<v-list-tile-content>
				<v-list-tile-title>Редактировать магазин</v-list-tile-title>
			</v-list-tile-content>
		</v-list-tile>
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
								v-model="name"
								:rules="nameRules"
								label="Название магазина"
								required
							></v-text-field>
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
    props: ['market'],
    data () {
      return {
				editDialog: false,
				valid: true,
				nameRules: [
					v => !!v || 'Необходимо указать название магазина',
					v => (v && v.length <= 15 ) || 'Название магазина не более 15 символов'
				],
				name: this.market.name,
      }
		},
		watch : {
			market (market) {
				this.name = market.name
			}
		},
    methods: {
      onSaveChanges () {
        if (this.$refs.form.validate()) {
					this.editDialog = false
					this.$store.dispatch('editMarket', {
						Id: this.market.id,
						Name: this.name
					})
				}        
			}
    }
  }
</script>
