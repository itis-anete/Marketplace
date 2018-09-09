<template>
  <v-app>
		<v-navigation-drawer
      v-model="sideNav"
      absolute
      temporary
    >
      <v-list class="pt-0">
        <v-list-tile
				 v-for="item in menuItems"
				 :key="item.title"
				 @click=""
				 :to="item.link"
				>
          <v-list-tile-action>
            <v-icon> {{ item.icon }} </v-icon>
          </v-list-tile-action>

          <v-list-tile-content>
            <v-list-tile-title> {{ item.title }} </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
		<v-toolbar dark class="primary">			
			<v-toolbar-side-icon
			 @click="sideNav = !sideNav"
			 class="hidden-sm-and-up"
			></v-toolbar-side-icon>
			<v-toolbar-title>
				<router-link 
					to="/" 
					tag="span" 
					style="cursor: pointer"
				>
					Marketplace
				</router-link> 
			</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-toolbar-items class="hidden-xs-only">
				<v-btn 
					flat 
					v-for="item in menuItems" 
					:key="item.title"
					:to="item.link"
				>
					<v-icon left> {{item.icon}} </v-icon>
					{{item.title}}
				</v-btn>
			</v-toolbar-items>
		</v-toolbar>
		<main>
			<transition name="slide-fade" mode="out-in">
			<router-view></router-view>
			</transition>
		</main>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      sideNav: null,
    }
	},
	computed: {
		menuItems () {
			return [
				{ icon: "lock_open", title: "Магазины", link: "/markets" },
				{ icon: "lock_open", title: "Продукты", link: "/products" }
			]
		}
	},
	methods: {		
	},
  name: "App"
}
</script>

<style>
	.slide-fade-enter-active {
		transition: all .5s cubic-bezier(1.0, 0.5, 0.8, 1.0);
	}
	.slide-fade-leave-active {
		transition: all .5s cubic-bezier(1.0, 0.5, 0.8, 1.0);
	}
	.slide-fade-enter, .slide-fade-leave-to
	/* .slide-fade-leave-active до версии 2.1.8 */ {
		transform: translateX(30px);
		opacity: 0;
	} 
</style>

