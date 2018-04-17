import Vue from "vue"
import Router from "vue-router"
import App from "./App.vue"
import 'bootstrap/dist/css/bootstrap.css'

Vue.use(Router)

var router = new Router({
  routes: [
    { path: "/", component: resolve => require(["./Home.vue"], resolve) },
    { path: "/About", component: resolve => require(["./About.vue"], resolve) },
    { path: "/Contact", component: resolve => require(["./Contact.vue"], resolve) }
  ]
})

const app = new Vue({
  el: "#app",
  router,
  render: h => h(App)
})
