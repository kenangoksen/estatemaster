import Home from '../views/front/Home.vue';
import { createRouter, createWebHistory } from 'vue-router';
import Overview from '@/components/UserProfile/Overview.vue';
import UserList from '@/components/Users/List.vue';
 
const routes = [
     {
        path: '/',
        name: 'Home',
        component: Home
     },
     {
      path: '/user-profile/overview',
      name: 'Overview',
      component: Overview
     },
     {
      path: '/users/list',
      name: 'UserList',
      component: UserList
     }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;