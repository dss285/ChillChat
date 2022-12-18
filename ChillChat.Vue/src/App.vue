<script setup lang="ts">
import "./assets/main.scss";
import { RouterLink, RouterView } from "vue-router";
import Navbar from "./components/landing/Navbar.vue";
//import HelloWorld from "./components/HelloWorld.vue";
</script>




<template>
	<header>
        <Navbar></Navbar>
	</header>

    <Suspense>
        <RouterView />
    </Suspense>
</template>
