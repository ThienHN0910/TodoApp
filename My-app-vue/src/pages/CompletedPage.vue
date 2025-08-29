<script setup>
import { ref, computed, onMounted } from 'vue'
import { useTaskStore } from '@/stores/tasks'
import CompletedTasks from '@/components/CompletedTasks.vue'
const taskStore = useTaskStore()
const query = ref('')
const filteredTasks = computed(() => {
  const q = query.value.trim().toLowerCase()
  if (!q) return taskStore.completedTasks
  return taskStore.completedTasks.filter((t) => (t.name ?? '').toLowerCase().includes(q))
})

onMounted(() => {
  if (!taskStore.isLoaded) taskStore.fetchTasks()
})
</script>
<template>
  <h3>Completed Page</h3>
  <br />
  <form @submit.prevent class="row g-3">
    <div class="col-auto">
      <label for="searchInput" class="visually-hidden">Search tasks</label>
      <input
        id="searchInput"
        type="text"
        v-model.trim="query"
        class="form-control"
        placeholder="Enter to search"
      />
    </div>
    <div class="col-auto"><button type="submit" class="btn btn-primary mb-3">Search</button></div>
  </form>
  <br />
  <CompletedTasks :tasks="filteredTasks" />
</template>
<style scoped></style>
