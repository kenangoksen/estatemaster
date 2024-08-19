<template>
  <Navbar></Navbar>
  <SideBar></SideBar>
  <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
    <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
      <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
      </div>
    </div>
  </div>
  <router-view />
</template>

<script setup>
import Navbar from './components/parts/Navbar.vue';
import SideBar from './components/parts/SideBar.vue';
</script>

<style scoped></style>
