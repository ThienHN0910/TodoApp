import { defineStore } from 'pinia'
import type { Task } from '@/types/itask'
import { getTasks, createTask, toggleStatus, deleteTask } from '@/services/api'

export const useTaskStore = defineStore('taskStore', {
  state: () => ({
    tasks: [] as Task[],
    isLoaded: false,
    loading: false,
    error: null as string | null,
  }),

  getters: {
    ongoingTasks: (state): Task[] => state.tasks.filter((task) => !task.completed),
    completedTasks: (state): Task[] => state.tasks.filter((task) => task.completed),
    taskById: (state) => (id: number) => state.tasks.find((task) => task.id === id),
  },

  actions: {
    async fetchTasks() {
      this.loading = true
      this.error = null
      try {
        const data = await getTasks()
        this.tasks = data.map((t: any) => ({
          ...t,
          completed:
            typeof t.completed !== 'undefined' ? t.completed : t.status === true || t.status === 1,
        }))
        this.isLoaded = true
      } catch (err: unknown) {
        if (typeof err === 'object' && err && 'message' in err) {
          this.error = (err as { message: string }).message
        } else {
          this.error = 'Failed to fetch tasks'
        }
      } finally {
        this.loading = false
      }
    },

    async addTask(name: string, deadline: string, priority: string) {
      this.loading = true
      this.error = null
      try {
        await createTask({ name, deadline, priority })
        await this.fetchTasks()
      } catch (err: unknown) {
        if (typeof err === 'object' && err && 'message' in err) {
          this.error = (err as { message: string }).message
        } else {
          this.error = 'Failed to add task'
        }
      } finally {
        this.loading = false
      }
    },

    async markCompleted(id: number) {
      this.loading = true
      this.error = null
      try {
        await toggleStatus(id)
        await this.fetchTasks()
      } catch (err: unknown) {
        if (typeof err === 'object' && err && 'message' in err) {
          this.error = (err as { message: string }).message
        } else {
          this.error = 'Failed to update status'
        }
      } finally {
        this.loading = false
      }
    },

    async removeTask(id: number) {
      this.loading = true
      this.error = null
      try {
        await deleteTask(id)
        await this.fetchTasks()
      } catch (err: unknown) {
        if (typeof err === 'object' && err && 'message' in err) {
          this.error = (err as { message: string }).message
        } else {
          this.error = 'Failed to delete task'
        }
      } finally {
        this.loading = false
      }
    },
  },
})
