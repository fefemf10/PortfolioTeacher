import { createWebHistory, createRouter, RouteRecordRaw } from 'vue-router'
const pages = import.meta.glob('./pages/**/*.vue')

function lazy(page) {
  const path = `./pages/${page}.vue`;
  const loader = pages[path];
  return loader;
}

const Login = lazy('Account/Login')
const Logout = lazy('Account/Logout')

const routes: RouteRecordRaw[] = [
  { path: '/account/login:ReturnUrl?', component: Login },
  { path: '/account/logout:logoutId?', component: Logout },
]

const router = createRouter({
  history: createWebHistory('/id'),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  }
})

export default router
