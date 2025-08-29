<script setup>
import { ref, computed } from 'vue'
import { useTaskStore } from '@/stores/tasks'

const props = defineProps({
  tasks: [],
})

const taskStore = useTaskStore()

const ongoing = computed(() => props.tasks)

function formatDate(date) {
  return new Date(date).toLocaleDateString()
}

function handleDelete(id) {
  taskStore.removeTask(id)
}
function handleToggle(id) {
  taskStore.markCompleted(id)
}
</script>

<template>
  <div>
    <h5>Ongoing Tasks</h5>

    <ul class="list-group mb-2">
      <li
        v-for="task in ongoing"
        :key="task.id"
        class="list-group-item d-flex justify-content-between align-items-center"
      >
        <div>
          <strong>{{ task.name }}</strong>
          <br />
          <small> Deadline: {{ formatDate(task.deadline) }} | Priority: </small>
          <small v-if="task.priority == 'important'" class="text-danger">
            {{ task.priority }}
          </small>
          <small v-else-if="task.priority == 'optional'" class="text-secondary">
            {{ task.priority }}
          </small>
          <small v-else class="text-warning">
            {{ task.priority }}
          </small>
        </div>
        <div class="form-check form-switch">
          <input
            type="checkbox"
            v-model="task.completed"
            @click="handleToggle(task.id)"
            class="form-check-input"
            id="flexSwitchCheckDefault"
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
