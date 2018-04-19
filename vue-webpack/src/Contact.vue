<template>
  <div class="page page-contact">
    <!-- page-contact.html -->
    <h1>Tons of Animations</h1>
    <h2>Contact</h2>

    <router-link to="/" class="btn btn-primary btn-lg">Home</router-link>
    <router-link to="/about" class="btn btn-success btn-lg">About</router-link>
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
.page-contact {
  background: #ffa6bb;
  color: #9e0000;
}

.action-enter-active,
.action-leave-active {
  transform-origin: 50% 50%;
  animation: rotateOutNewspaper 1s both ease-in;
}

.action-enter,
.action-leave-to {
  animation: slideInUp 1s both ease-in;
}
</style>