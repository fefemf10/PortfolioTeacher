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

const routes = [
  { path: '/', component: Home, meta: { requiresAuth: true } },
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
  { path: '/authentication/login-callback', component: LoginCallback },
  { path: '/authentication/logout-callback', component: LogoutCallback },
  { path: '/authentication/silent-callback', component: SilentCallback },
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
