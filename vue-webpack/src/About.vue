<template>
  <div class="page page-about">
    <!-- page-about.html -->
    <h1>Animating Pages Is Fun</h1>
    <h2>About</h2>

    <router-link to="/" class="btn btn-primary btn-lg">Home</router-link>
    <router-link to="/contact" class="btn btn-danger btn-lg">Contact</router-link>
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
.page-about {
  background: #e59400;
  color: #a55400;
}

.action-enter-active,
.action-leave-active {
  animation: slideInRight 1s both ease-in;
}

.action-enter,
.action-leave-to {
  animation: slideOutLeft 1s both ease-in;
}
</style>