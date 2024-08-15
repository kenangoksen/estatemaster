<template>
      <Navbar></Navbar>
      <SideBar></SideBar>
  <router-view />
</template>

<script setup> 
import Navbar from './components/parts/Navbar.vue';
import SideBar from './components/parts/SideBar.vue';
</script>

<style scoped>
 
</style>
