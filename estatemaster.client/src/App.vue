<template>
  <div
    v-if="$route.matched.some(({ name }) => (name === 'Login' || name === 'Logout' || name === 'HelpPage' || name === 'ScreenLock'
      || name === 'ResetPassword' || name === 'ForgotPassword')) == false">
    <Navbar></Navbar>
    <SideBar></SideBar>
    <PageLoader ref="pageLoader" />
  </div>
  
  <router-view :key="$route.fullPath"/>
</template>

<script setup>
import Navbar from './components/parts/Navbar.vue';
import SideBar from './components/parts/SideBar.vue';
import PageLoader from './components/Helpers/PageLoader.vue';
import { useStore } from 'vuex';
import { onMounted } from 'vue';
// import Login from './components/Login.vue';

const store = useStore();

onMounted(() => {
  store.dispatch('fetchUser'); // Kullanıcı bilgilerini fetch et
});
</script>

<style scoped></style>
