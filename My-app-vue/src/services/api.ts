import axios from 'axios'

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5203',
  headers: { 'Content-Type': 'application/json' },
  withCredentials: false,
})

// Task API functions
import type { Task } from '@/types/itask'

export async function getTasks(): Promise<Task[]> {
  const res = await api.get('/api/Task/getTasks')
  return res.data
}

export async function createTask(task: {
  name: string
  deadline: string
  priority: string
}): Promise<void> {
  await api.post('/api/Task/CreateTask', task)
}

export async function toggleStatus(id: number): Promise<void> {
  await api.patch(`/api/Task/${id}/status`)
}

export async function deleteTask(id: number): Promise<void> {
  await api.delete(`/api/Task/${id}`)
}
