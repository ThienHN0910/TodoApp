<script setup>
import { computed } from 'vue'
import { useTaskStore } from '@/stores/tasks'

const props = defineProps({
  tasks: Array,
})

const taskStore = useTaskStore()
const completed = computed(() => props.tasks)

function handleDelete(id) {
  taskStore.removeTask(id)
}
function handleToggle(id) {
  taskStore.markCompleted(id)
}
</script>

<template>
  <div>
    <h5>Completed Tasks</h5>

    <ul class="list-group mb-2">
      <li
        v-for="task in completed"
        :key="task.id"
        class="list-group-item d-flex justify-content-between align-items-center"
      >
        <div>
          <s class="bg-secondary bg-gradient">{{ task.name }}</s>
          <br />
          <small class="text-success">Completed</small>
          <small> Priority: {{ task.priority }}</small>
        </div>
        <div class="form-check form-switch">
          <input
            type="checkbox"
            v-model="task.completed"
            @click="handleToggle(task.id)"
            class="form-check-input"
            id="flexSwitchCheckChecked"
            checked
          />
          <button class="btn btn-danger btn-sm" @click="handleDelete(task.id)" title="Delete task">
            <i class="bi bi-trash"></i> Delete
          </button>
        </div>
      </li>
    </ul>
  </div>
</template>

<style scoped></style>
