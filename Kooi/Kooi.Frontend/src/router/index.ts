// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path: 'login',
        name: 'login',

        component: () => import(/* webpackChunkName: "home" */ '@/views/LoginView.vue'),
      },

      {
        path: 'register',
        name: 'register',

        component: () => import(/* webpackChunkName: "home" */ '@/views/RegisterView.vue'),
      },
      
      //different sidebar layout, a list select display
      {
        path: 'admintesting',
        name: 'admintesting',

        component: () => import(/* webpackChunkName: "home" */ '@/views/AdminPageView1.vue'),
      },
    
      {
        path: 'admin',
        name: 'admin',

        component: () => import(/* webpackChunkName: "home" */ '@/views/AdminPageView2.vue'),
      },

      {
        path: 'tooltips',
        name: 'tooltips',

        component: () => import(/* webpackChunkName: "home" */ '@/views/TooltipsView.vue'),
      },
    ],
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
