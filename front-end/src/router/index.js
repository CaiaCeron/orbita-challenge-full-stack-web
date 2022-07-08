import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'About-page',
    component: () => import('../views/About-View.vue')
  },
  {
    path: '/alunos',
    name: 'students',
    component: () => import('../views/StudentsConsult-View.vue')
  },
  {
    path: '/alunos/cadastro',
    name: 'registry',
    component: () => import('../views/StudentRegistration-View.vue')
  },
  {
    path: '/alunos/editar',
    name: 'edit',
    component: () => import('../views/EditRegistry-View.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
