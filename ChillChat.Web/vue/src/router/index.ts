import { createRouter, createWebHistory } from "vue-router";
import LandingPageView from "../views/LandingPageView.vue";
import SignalDemoView from "../views/SignalDemoView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: LandingPageView,
    },
    {
      path: "/about",
      name: "about",
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("../views/AboutView.vue"),
    },
    {
      path : "/chat",
      name: "chat",
      component: () => import("../views/chat/ChatView.vue")
    },
    {
      path: "/signaldemo",
      name: "signaldemo",
      component: SignalDemoView,
    }
    
  ],
});

export default router;
