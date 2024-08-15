import Home from '../views/front/Home.vue';
import { createRouter, createWebHistory } from 'vue-router';
import Overview from '@/components/UserProfile/Overview.vue';


// import SecureLS from "secure-ls";  
// const ls = new SecureLS({ isCompression: false });
 
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
     }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;