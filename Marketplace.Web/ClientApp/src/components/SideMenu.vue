<template>
	<v-container class="panel" fluid>
		<v-flex xs12 class="text-xs-right">
			<v-btn fab small @click.stop="drawer = !drawer" >
				<v-icon dark>list</v-icon>
			</v-btn>
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
	</v-container>
</template>

<script>
export default {
	props: ['items'],
	data() {
    return {
			drawer: null,
    }
	},
	methods: {
		navigate(path){
			this.$router.push(path)
		}
	},
}
</script>

<style scoped>
	.panel {
		box-shadow: inset 0px -2px 0px 0px #039be5, 0px 0px 10px 5px rgba(0,0,0,0.3);
	}
</style>
