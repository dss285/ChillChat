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


    <Suspense>
        <RouterView />
    </Suspense>
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
    --color-deco-darkbrown: rgb(58, 36, 15);
    --color-deco-blue: #0B1030;

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
    --margin-large: 250px;


}

html {
    scroll-behavior: var(--setting-scrollbehavior);
    font-size: var(--setting-font-size);
    
}

.btn-full {width: 100%;}
.btn-half {width: 50%;}

.landing {
    
    background-color: var(--color-primary);
    color: var(--setting-font-color);
    font-family: 'Kanit', sans-serif;
    min-height: 100vh;
    padding: 0px;
    margin: 0px;

    section {
        padding: var(--setting-padding-primary);
    }

    section.top {
        background-color: rgb(20,53,238);
        background: linear-gradient(140deg, rgba(20,53,238,1) 0%, rgba(12,18,54,1) 20%, rgba(0,0,0,1) 100%); 
        min-height: 100vh;
        clip-path: polygon(0 0, 100% 0, 100% 100%, 93% 88%, 79% 94%, 64% 98%, 53% 92%, 30% 95%, 15% 93%, 0 100%);
        .promobox {
            margin-top: 20vh;
            text-align: center;
            font-size: 1.5em;
        }

        .title {
            font-size: 3em;
        }

        .services {
            margin-top: 20vh;
            margin-bottom: 20vh;
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


    section.center {
        margin-top: var(--margin-large);
        background-color: var(--color-primary);
        min-height: 100vh;


        section.textimgarea {
            font-size: 1.5em;
            border-bottom: 4px solid var(--color-secondary);
            margin-top: var(--margin-primary);

            .button {
                margin-top: var(--margin-primary);
            }

            img {
                border-radius: var(--setting-Bradius-primary);
            }
        }
    }


    footer {
        min-height: 20vh;
        background-color: var(--color-deco-blue);
        margin-top: var(--margin-primary);
    }
}


</style>
