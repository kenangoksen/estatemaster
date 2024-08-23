<template>
    <div v-if="isLoading" class="page-loader flex-column bg-dark bg-opacity-25">
      <span class="spinner-border text-primary" role="status"></span>
      <span class="text-gray-800 fs-6 fw-semibold mt-5">Loading...</span>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        isLoading: false
      };
    },
    methods: {
      show() {
        this.isLoading = true;
      },
      hide() {
        this.isLoading = false;
      }
    }
  };
  </script>

<style scoped>
.page-loader {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 9999;
}
</style>