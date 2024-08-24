import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VueSweetalert2 from 'vue-sweetalert2'
import 'sweetalert2/dist/sweetalert2.min.css'
import axios from 'axios'
import Pagination from 'v-pagination-3'
import store from './store/index.js'

const app = createApp(App)
app.use(router); 
app.use(VueSweetalert2);
app.use(store);

app.component('pagination', Pagination);

app.mount('#app');

// Axios isteklerinde pageLoader'ı kullanmak için app.mount'tan sonra erişim sağlayın
app.config.globalProperties.$pageLoader = app._instance.proxy.$refs.pageLoader;

// Router geçişlerinde pageLoader'ı kullanmak için beforeEach ve afterEach ekleyin
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
