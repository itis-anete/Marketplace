<template>
  <v-container fluid class="pl-0 pb-0 pt-0 pr-0"> 		
		<side-menu :items="this.items"></side-menu>
  	<v-container grid-list-xl fluid>
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
	        <v-list-tile
	          v-for="item in items"
	          :key="item.title"
						@click="navigate(item.path)"
	        >
						<v-list-tile-action>
							<v-icon>{{ item.icon }}</v-icon>
						</v-list-tile-action>
	
						<v-list-tile-content>
							<v-list-tile-title>{{ item.title }}</v-list-tile-title>
						</v-list-tile-content>
	        </v-list-tile>
	      </v-list>
	    </v-navigation-drawer>
	
			<transition-group name="slide" tag="v-layout" class="row wrap justify-center">
				<v-flex xs12 sm2 v-for="product in products" :key="product.id" style="min-width:290px">
							<v-card :key="product.id">
								<v-card-title primary-title class="accent white--text" style="min-height: 70px">
									{{product.name}}
									<v-spacer></v-spacer>
									<v-btn flat icon color="white" @click="deleteProduct(product.id)"><v-icon>delete</v-icon></v-btn>
								</v-card-title>
							</v-card>
				</v-flex>
			</transition-group>	
	
		</v-container>
  </v-container>
</template>

<script>
	export default {
  data() {
    return {
			drawer: null,	
			items: [
				{ title: 'Создать товар', icon: 'add', path: '/products/new' }
      ]
    }
	},
	computed: {
		products () {
			return this.$store.getters.products
		},loading () {
			return this.$store.getters.loading
		}
	},
	methods: {
		deleteProduct (id) {
			this.$store.dispatch('deleteProduct', id)
		},
		navigate(path){
			this.$router.push(path)
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

