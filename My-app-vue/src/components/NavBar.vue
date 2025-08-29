<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <nav class="navbar navbar-light bg-light">
    <ul class="nav nav-tabs">
      <li class="nav-item">
        <RouterLink to="/" class="nav-link">Home</RouterLink>
      </li>
      <!-- <li class="nav-item">
        <RouterLink to="/login" class="nav-link">Login</RouterLink>
      </li> -->
      <li class="nav-item">
        <RouterLink to="/completed" class="nav-link">Completed task</RouterLink>
      </li>
      <li class="nav-item">
        <RouterLink to="/ongoing" class="nav-link">Ongoing task</RouterLink>
      </li>
    </ul>
  </nav>
</template>

<style scoped></style>
