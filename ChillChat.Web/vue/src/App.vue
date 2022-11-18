<script setup lang="ts">
//import "./assets/styles/style.sass";
import { RouterLink, RouterView } from "vue-router";
import Navbar from "./components/landing/Navbar.vue";
//import HelloWorld from "./components/HelloWorld.vue";
</script>




<template>
	<header>
        <Navbar></Navbar>
	</header>

	<RouterView />

</template>


<style lang="scss">


:root {
    //Primary colors
    //primary,secondary,tertiary,quaternary, quinary, senary, septenary, octonary, nonary, denary
    --color-primary: black;
    --color-secondary: gray;
    --color-tertiary: lightgray;
    --color-quaternary: white;

    //Spesific decoration colors
    --color-deco-purple: purple;

    //Color utility
    //These are meant for warnings etc....
    --color-utility-green: green;
    --color-utility-yellow: yellow;
    --color-utility-red: red;

    //Font settings
    --setting-font-size: 16px;
    --setting-font-color: var(var(--color-quaternary));

    //Padding & rounding
    --setting-padding-primary: 10px;
    --setting-padding-secondary: 5px;
    --setting-Bradius-primary: 5px;

    //Misc
    --setting-scrollbehavior: smooth;


}

html {
    scroll-behavior: var(--setting-scrollbehavior);
    font-size: var(--setting-font-size);

}

.landing {

    background-color: var(--color-primary);
    min-height: 100vh;
}

</style>
