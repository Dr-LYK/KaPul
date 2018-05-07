// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css';
import VueSession from 'vue-session'

import langFr from 'element-ui/lib/locale/lang/fr'
import locale from 'element-ui/lib/locale'

import {CONFIG} from "./config";
import {HTTP} from "./http-common";

import 'element-ui/lib/theme-chalk/index.css'

locale.use(langFr);

Vue.use(VueSession);
Vue.use(ElementUI);

Vue.config.productionTip = false;
Vue.prototype.$http = HTTP;
Vue.prototype.$config = CONFIG;

/* eslint-disable no-new */
new Vue(
{
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
});
