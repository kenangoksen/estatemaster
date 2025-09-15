<template>
  <div v-if="shouldShowMainLayout">
    <Navbar></Navbar>
    <SideBar></SideBar>
    <PageLoader ref="pageLoader" />
  </div>

  <router-view :key="$route.fullPath"/>
</template>

<script>
import Navbar from './components/parts/Navbar.vue';
import SideBar from './components/parts/SideBar.vue';
import PageLoader from './components/Helpers/PageLoader.vue';
// import { useStore } from 'vuex'; // Eğer kullanmıyorsanız kaldırın
// import { onMounted } from 'vue'; // Eğer kullanmıyorsanız kaldırın

export default {
  name: "App",
  components: {
    Navbar,
    SideBar,
    PageLoader
  },
  computed: {
    shouldShowMainLayout() {
      // Ana layout'u göstermemesi gereken rotaların listesi
      const noMainLayoutRoutes = [
        'Login',
        'Logout',
        'HelpPage',
        'ScreenLock',
        'ResetPassword',
        'ForgotPassword',
        'SelfRegistration', // BURASI EKLENDİ
        'CompanyCreate'     // BURASI EKLENDİ
      ];
      // Mevcut rotanın adının bu listede olup olmadığını kontrol et
      return !noMainLayoutRoutes.includes(this.$route.name);
    }
  }
}
</script>

<style scoped>
/* Scoped stilleriniz */
</style>