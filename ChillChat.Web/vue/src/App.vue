<script setup lang="ts">
//import "./assets/styles/style.sass";
import { RouterLink, RouterView } from "vue-router";
//import HelloWorld from "./components/HelloWorld.vue";
</script>




<template>
	<header>
		<div class="wrapper">
			<nav>
				<RouterLink to="/">Home</RouterLink>
				<RouterLink to="/about">About</RouterLink>
				<RouterLink to="/chat">chat</RouterLink>
				<RouterLink to="/signaldemo">SignalR demo</RouterLink>
			</nav>
		</div>
	</header>
	<RouterView />
</template>


<style scoped lang="scss">
  //@import "./assets/styles/style.sass";

nav {
	ul {
		margin: 0;
		padding: 0;
		list-style: none;
	}

	li { display: inline-block; }

	a {
		display: block;
		padding: 6px 12px;
		text-decoration: none;
	}
}  

</style>
