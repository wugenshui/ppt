<template>
  <div class="page page-home">
    <!-- page-home.html -->
    <h1>Vue Animations Shenanigans</h1>
    <h2>Home</h2>

    <router-link to="/about" class="btn btn-success btn-lg">Go to About</router-link>
    <router-link to="/contact" class="btn btn-danger btn-lg">Go to Contact</router-link>
  </div>
</template>

<script>
export default {
  data: function() {
    return {}
  }
}
</script>

<style scoped>
.page-home {
  background: #00d0bc;
  color: #00907c;
}

.action-enter-active,
.action-leave-active {
  animation: scaleUp 1s both ease-in;
}

.action-enter,
.action-leave-to {
  transform-origin: 0% 0%;
  animation: rotateFall 1s both ease-in;
}
</style>