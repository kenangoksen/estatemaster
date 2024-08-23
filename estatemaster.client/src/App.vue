<template>
  <Navbar></Navbar>
  <SideBar></SideBar>
  <PageLoader ref="pageLoader" />
  <router-view />
</template>

<script setup>
import Navbar from './components/parts/Navbar.vue';
import SideBar from './components/parts/SideBar.vue';
import PageLoader from './components/Helpers/PageLoader.vue';
</script>

<style scoped></style>
