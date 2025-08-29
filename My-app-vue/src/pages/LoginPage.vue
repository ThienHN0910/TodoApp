<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
const email = ref("");
const password = ref("");
const router = useRouter();

const handleLogin = () => {
  router.push("/");
};
</script>
<template>
  <div class="container d-flex justify-content-center align-items-center vh-100">
    <div class="card p-4 shadow" style="width: 100%; max-width: 400px">
      <h2 class="text-center mb-4">Login</h2>
      <form @submit.prevent="handleLogin">
        <div class="mb-3">
          <label for="email" class="form-label">Email address</label>
          <input type="email" class="form-control" id="email" v-model="email" required />
        </div>
        <div class="mb-3">
          <label for="password" class="form-label">Password</label>
          <input
            type="password"
            class="form-control"
            id="password"
            v-model="password"
            required
          />
        </div>
        <button type="submit" class="btn btn-primary w-100">Login</button>
      </form>
    </div>
  </div>
</template>

<style scoped></style>
