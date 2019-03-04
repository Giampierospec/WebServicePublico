import Vue from 'vue'
import Change from './Components/Change.vue';
import Inflacion from './Components/Inflacion.vue';
import Log from './Components/Log.vue';
import SaludFinanciera from './Components/SaludFinanciera.vue';
import HistorialCrediticio from './Components/HistorialCrediticio.vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
const routes = [
  { path: '/', component: Change },
  { path: '/inf', component: Inflacion },
  { path: '/log', component: Log },
  { path: '/salud', component: SaludFinanciera },
  { path: '/hcrediticio', component: HistorialCrediticio }];
const router = new VueRouter({
  routes
});
new Vue({
  router
}).$mount("#app");
