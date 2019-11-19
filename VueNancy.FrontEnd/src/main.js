import Vue from 'vue';
import App from './App.vue';
import ShardsVue from 'shards-vue';
import 'shards-ui/dist/css/shards.css';

Vue.use(ShardsVue);
Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
