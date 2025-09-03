<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'
import { useTaskStore } from '@/stores/tasks'
import CompletedTasks from '@/components/CompletedTasks.vue'
const taskStore = useTaskStore()
const query = ref(' ')
const sortKey = ref('')
const filtered = computed(() => {
  const q = query.value.trim().toLowerCase()
  const src = taskStore.completedTasks
  if (!q) return src
  return src.filter((t: any) => t.name.toLowerCase().includes(q))
})
const filteredTasks = computed(() => {
  const arr = filtered.value.slice()
  if (sortKey.value === 'name') {
    arr.sort((a: any, b: any) => (a.name ?? '').localeCompare(b.name ?? ''))
  } else if (sortKey.value === 'deadline') {
    arr.sort((a: any, b: any) => {
      return Date.parse(a.deadline) - Date.parse(b.deadline)
    })
  }
  return arr
})
function sortByName() {
  sortKey.value = 'name'
}
function sortByDeadline() {
  sortKey.value = 'deadline'
}
onMounted(() => {
  if (!taskStore.isLoaded) taskStore.fetchTasks()
})
</script>
<template>
  <h3>Completed Page</h3>
  <br />
  <form @submit.prevent="filteredTasks" class="row g-3">
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
  <div class="dropdown">
    <button
      class="btn btn-secondary dropdown-toggle"
      type="button"
      id="dropdownMenuButton1"
      data-bs-toggle="dropdown"
      aria-expanded="false"
    >
      Dropdown button
    </button>
    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
      <li><button class="dropdown-item" @click="sortByName">Sort by name</button></li>
      <li>
        <button class="dropdown-item" @click="sortByDeadline" disabled>Sort by deadline</button>
      </li>
    </ul>
  </div>
  <br />
  <CompletedTasks :tasks="filteredTasks" />
</template>
<style scoped></style>
