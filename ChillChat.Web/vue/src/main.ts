import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

//Importing bootstrap to the project
//We might wanna consider using vue-bootstrap beacause of it's premade components for vue
//Time of writing this it has not yet been updated for Bootstrap 5 but we can start without it.
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';


const app = createApp(App);


app.use(router);

app.mount("#app");
