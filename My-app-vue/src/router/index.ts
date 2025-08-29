import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import CompletedPage from '../pages/CompletedPage.vue'
import OngoingPage from '../pages/OngoingPage.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('@/pages/LoginPage.vue')
    },
    {
      path: '/completed',
      name: 'completed',
      component: CompletedPage,
    },
    {
      path: '/ongoing',
      name: 'ongoing',
      component: OngoingPage
    },
  ],
})

export default router
