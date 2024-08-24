import Home from '../views/front/Home.vue';
import { createRouter, createWebHistory } from 'vue-router';
import Overview from '@/components/UserProfile/Overview.vue';
import UserProfileProjects from '@/components/UserProfile/Projects.vue';
import UserList from '@/components/Users/List.vue';
import UserCreate from '@/components/Users/Create.vue';
import UserUpdate from '@/components/Users/Update.vue';
 
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
      path: '/user-profile/projects',
      name: 'Projects',
      component: UserProfileProjects
     },
     {
      path: '/user/list',
      name: 'UserList',
      component: UserList,
      props: true
     },
     {
        path: '/user/create',
        name: 'UserCreate',
        component: UserCreate
     },
     {
        path: '/user/update/:id',
        name: 'UserUpdate',
        component: UserUpdate,
        props: true
     },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;