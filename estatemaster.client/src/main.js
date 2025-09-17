import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VueSweetalert2 from 'vue-sweetalert2'
import 'sweetalert2/dist/sweetalert2.min.css'
import axios from 'axios'
import Pagination from 'v-pagination-3'
import store from './store/index.js'
import SecureLS from "secure-ls";
import mitt from 'mitt';

const emitter = mitt();
const app = createApp(App);
const ls = new SecureLS({ isCompression: true, encodingType: 'aes' });

app.use(router);
app.use(VueSweetalert2);
app.use(store);

app.component('pagination', Pagination);

app.mount('#app');
app.config.globalProperties.emitter = emitter;
app.config.globalProperties.$pageLoader = app._instance.proxy.$refs.pageLoader;

app.config.globalProperties.$getUser = function () {
  var data = {};
  try {
    data = ls.get('user_' + sessionStorage.getItem('sid'));
  }
  catch (Err) {
    console.error(Err);
  }
  return data;
};

router.beforeEach((to, from, next) => {
  app.config.globalProperties.$pageLoader.show();
  next();
});

router.afterEach(() => {
  app.config.globalProperties.$pageLoader.hide();
});

axios.interceptors.request.use(config => {
  app.config.globalProperties.$pageLoader.show();
  return config;
}, error => {
  app.config.globalProperties.$pageLoader.hide();
  return Promise.reject(error);
});

axios.interceptors.response.use(response => {
  app.config.globalProperties.$pageLoader.hide();
  return response;
}, error => {
  app.config.globalProperties.$pageLoader.hide();
  return Promise.reject(error);
});