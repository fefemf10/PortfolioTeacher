import { createWebHistory, createRouter } from 'vue-router'
import LoginCallback from './LoginCallback.vue'
import LogoutCallback from './LogoutCallback.vue'
import SilentCallback from './SilentCallback.vue'
import userManager, { login } from './oidc'

import Home from './pages/Home.vue'
import About from './pages/About.vue'
import Awards from './pages/Awards.vue'
import Dean from './pages/Dean.vue'
import Deputy from './pages/Deputy.vue'
import Disciplines from './pages/Disciplines.vue'
import Dissertation from './pages/Dissertation.vue'
import ProfessionalDevelopments from './pages/ProfessionalDevelopments.vue'
import PublicActivities from './pages/PublicActivities.vue'
import ScienceProjects from './pages/ScienceProjects.vue'
import Stats from './pages/Stats.vue'
import University from './pages/University.vue'
import Work from './pages/Work.vue'
import Admin from './pages/Admin.vue'
import Resume from './pages/Resume.vue'


import Page404 from './pages/404.vue'
import Page403 from './pages/403.vue'
import Page500 from './pages/500.vue'
import Page418 from './pages/418.vue'

const routes = [
  { path: '/', component: Home },
  { path: '/about', component: About },
  { path: '/awards', component: Awards },
  { path: '/dean', component: Dean },
  { path: '/deputy', component: Deputy },
  { path: '/disciplines', component: Disciplines },
  { path: '/dissertation', component: Dissertation },
  { path: '/professionalDevelopments', component: ProfessionalDevelopments },
  { path: '/publicActivities', component: PublicActivities },
  { path: '/scienceProjects', component: ScienceProjects },
  { path: '/stats', component: Stats },
  { path: '/university', component: University },
  { path: '/work', component: Work },
  { path: '/admin', component: Admin },
  { path: '/resume/:id', component: Resume },
  { path: '/authentication/login-callback', component: LoginCallback },
  { path: '/authentication/logout-callback', component: LogoutCallback },
  { path: '/authentication/silent-callback', component: SilentCallback },
  { path: "/404", component: Page404 },
  { path: "/403", component: Page403 },
  { path: "/500", component: Page500 },
  { path: "/418", component: Page418 },
  { path: "/:catchAll(.*)", component: Page404 },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth) {
    userManager.getUser().then(user => {
      if (!user || user.expired) {
        login();
      }
      else {
        next();
      }
    }).catch(error => {
      console.error('Route guard error:', error);
      login();
    });
  } else {
    next();
  }
});

export default router
