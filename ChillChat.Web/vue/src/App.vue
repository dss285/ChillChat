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

@import url('https://fonts.googleapis.com/css2?family=Kanit:wght@300&display=swap');

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
    --setting-font-color: white;

    //Padding & rounding
    --setting-padding-primary: 25px;
    --setting-padding-secondary: 10px;
    --setting-Bradius-primary: 5px;
    --setting-Bradius-secondary: 10px;

    //Misc
    --setting-scrollbehavior: smooth;
    --setting-transition-primary: 0.25s;

    //Margins
    --margin-primary: 50px;
    --margin-secondary: 25px;
    --margin-tertiary: 15px;


}

html {
    scroll-behavior: var(--setting-scrollbehavior);
    font-size: var(--setting-font-size);
    
}

.landing {
    
    background-color: var(--color-primary);
    background: rgb(20,53,238);
    background: linear-gradient(140deg, rgba(20,53,238,1) 0%, rgba(12,18,54,1) 20%, rgba(0,0,0,1) 100%); 


    min-height: 100vh;
    color: var(--setting-font-color);
    font-family: 'Kanit', sans-serif;

    .promobox {
        margin-top: 20vh;
        text-align: center;
        font-size: 1.5em;
        .title {
            font-size: 3em;
        }
    }

    
    .services {
        margin-top: 20vh;
        .servicebox {
            border: 4px solid var(--color-secondary);
            border-radius: var(--setting-Bradius-secondary);
            padding: var(--setting-padding-secondary);
            transition: var(--setting-transition-primary);
            cursor: pointer;

            &:hover {
                border: 4px solid var(--color-tertiary);
                //box-shadow: 0px 0px 45px 10px rgba(238, 17, 164, 0.75);
            }
        }

        .title {
            text-align: center;
            padding: var(--setting-Bradius-secondary);
            margin-bottom: var(--margin-primary)
        }
    }
    
}

</style>
