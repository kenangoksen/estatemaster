import { createRouter, createWebHistory } from 'vue-router';
import SecureLS from "secure-ls";
const ls = new SecureLS({ isCompression: true, encodingType: 'aes' });

import Home from '../views/front/Home.vue';
import Overview from '@/components/UserProfile/Overview.vue';
import UserProfileProjects from '@/components/UserProfile/Projects.vue';
import UserList from '@/components/Users/List.vue';
import UserCreate from '@/components/Users/Create.vue';
import UserUpdate from '@/components/Users/Update.vue';
import Login from '@/components/Login.vue';
import PropertiesList from '@/components/Properties/List.vue';
import PropertiesCreate from '@/components/Properties/Create.vue';
import PropertiesUpdate from '@/components/Properties/Update.vue';

const routes = [
   {
      path: '/',
      name: 'Home',
      component: Home,
      meta: { requiresAuth: true }
   },
   {
      path: "/Login",
      name: "Login",
      component: Login,
      meta: { requiresAuth: false },
      props: true
   },
   {
      path: '/user-profile/overview',
      name: 'Overview',
      component: Overview,
      meta: { requiresAuth: true }
   },
   {
      path: '/user-profile/projects',
      name: 'Projects',
      component: UserProfileProjects,
      meta: { requiresAuth: true }
   },
   {
      path: '/user/list',
      name: 'UserList',
      component: UserList,
      props: true,
      meta: { requiresAuth: true }
   },
   {
      path: '/user/create',
      name: 'UserCreate',
      component: UserCreate,
      meta: { requiresAuth: true }
   },
   {
      path: '/user/update/:id',
      name: 'UserUpdate',
      component: UserUpdate,
      meta: { requiresAuth: true },
      props: true
   },
   {
      path: '/properties/list',
      name: 'PropertiesList',
      component: PropertiesList,
      meta: { requiresAuth: true },
      props: true
   },
   {
      path: '/properties/create',
      name: 'PropertiesCreate',
      component: PropertiesCreate,
      meta: { requiresAuth: true },
      props: true
   },
   {
      path: '/properties/update/:id',
      name: 'PropertiesUpdate',
      component: PropertiesUpdate,
      meta: { requiresAuth: true },
      props: true
   }
];

const router = createRouter({
   history: createWebHistory(),
   routes,
});

router.beforeEach((to, from, next) => {
   var GetAuthStorage = ls.get('user_' + sessionStorage.getItem('sid'));
   if (to.matched.some(record => record.meta.requiresAuth)) {
      if (!GetAuthStorage) {
         next('/login');
      } else {
         next();
      }
   } else {
      if (to.path === '/login' && GetAuthStorage) {
         next('/');
      } else {
         next();
      }
   }
});
router.afterEach((to, from) => {
   if (from.name === 'Home') {
      localStorage.removeItem('homePageRefreshed');
   }
});
router.beforeEach((to, from, next) => {
   // Kullanıcı oturum bilgisini SecureLS ile al
   const sessionId = sessionStorage.getItem('sid');
   const user = ls.get('user_' + sessionId);

   // Giriş gerektiren bir sayfa mı?
   if (to.matched.some(record => record.meta.requiresAuth)) {
      // Kullanıcı login değilse login sayfasına yönlendir
      if (!user) {
         next('/login');
      } else {
         next();
      }
   } else {
      // Login olmuş kullanıcı login sayfasına gitmek isterse ana sayfaya yönlendir
      if (to.path === '/login' && user) {
         next('/');
      } else {
         next();
      }
   }
});

export default router;