<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useTaskStore } from '@/stores/tasks'

import CompletedTasks from '../components/CompletedTasks.vue'
import OngoingTasks from '../components/OngoingTasks.vue'

const name = ref('')
const deadline = ref('')
const priority = ref('')
const router = useRouter()
const taskStore = useTaskStore()

async function addTask() {
  await taskStore.addTask(name.value, deadline.value, priority.value)
  name.value = ''
  deadline.value = ''
  priority.value = ''
}
onMounted(() => {
  if (!taskStore.isLoaded) taskStore.fetchTasks()
})

const goToCompletedPage = () => {
  router.push('/completed')
}
const goToOngoingPage = () => {
  router.push('/ongoing')
}
</script>
<template>
  <div class="container py-4">
    <h2 class="text-center mb-4">My Tasks</h2>
    <form @submit.prevent="addTask" class="row g-2 align-items-end mb-4">
      <div class="col-md-4">
        <label class="form-label">Task Name</label>
        <input v-model="name" class="form-control" required placeholder="Enter task name" />
      </div>
      <div class="col-md-3">
        <label class="form-label">Deadline</label>
        <input v-model="deadline" type="date" class="form-control" required />
      </div>
      <div class="col-md-3">
        <label class="form-label">Priority</label>
        <select v-model="priority" class="form-select" required>
          <option disabled value="">Select priority</option>
          <option value="important">Important</option>
          <option value="todo">To do</option>
          <option value="optional">Optional</option>
        </select>
      </div>
      <div class="col-md-2">
        <button class="btn btn-primary w-100">Add Task</button>
      </div>
    </form>
    <div v-if="taskStore.ongoingTasks.length > 0">
      <OngoingTasks :tasks="taskStore.ongoingTasks.slice(0, 5)" />
      <button @click="goToOngoingPage" class="btn btn-outline-primary btn-sm">Show more...</button>
    </div>
    <div v-if="taskStore.completedTasks.length > 0">
      <CompletedTasks :tasks="taskStore.completedTasks.slice(0, 5)" />
      <button @click="goToCompletedPage" class="btn btn-outline-primary btn-sm">
        Show more...
      </button>
    </div>
  </div>
</template>
