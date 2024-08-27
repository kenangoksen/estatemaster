import Home from '../views/front/Home.vue';
import { createRouter, createWebHistory } from 'vue-router';
import Overview from '@/components/UserProfile/Overview.vue';
import UserProfileProjects from '@/components/UserProfile/Projects.vue';
import UserList from '@/components/Users/List.vue';
import UserCreate from '@/components/Users/Create.vue';
import UserUpdate from '@/components/Users/Update.vue';
import Login from '@/components/Login.vue';

const routes = [
   {
      path: '/',
      name: 'Home',
      component: Home,
      meta: { requiresAuth: true }
   },
   {
      path: '/login',
      name: 'Login',
      component: Login
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
];

const router = createRouter({
   history: createWebHistory(),
   routes,
});

router.beforeEach((to, from, next) => {
   const token = localStorage.getItem('token');
   if (to.matched.some(record => record.meta.requiresAuth)) {
      if (!token) {
         next('/login');
      } else {
         next();
      }
   } else {
      if (to.path === '/login' && token) {
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
})

export default router;