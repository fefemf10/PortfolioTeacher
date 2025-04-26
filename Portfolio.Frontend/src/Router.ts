import { createWebHistory, createRouter } from 'vue-router'
import userManager, { login, role } from './oidc'

const Home = () => import('./pages/Home.vue')
const About = () => import('./pages/About.vue')
const Awards = () => import('./pages/Awards.vue')
const Dean = () => import('./pages/Dean.vue')
const Deputy = () => import('./pages/Deputy.vue')
const Disciplines = () => import('./pages/Disciplines.vue')
const Dissertation = () => import('./pages/Dissertation.vue')
const ProfessionalDevelopments = () => import('./pages/ProfessionalDevelopments.vue')
const PublicActivities = () => import('./pages/PublicActivities.vue')
const ScienceProjects = () => import('./pages/ScienceProjects.vue')
const Stats = () => import('./pages/Stats.vue')
const University = () => import('./pages/University.vue')
const Work = () => import('./pages/Work.vue')
const Admin = () => import('./pages/Admin.vue')
const Resume = () => import('./pages/Resume.vue')

const Page404 = () => import('./pages/404.vue')
const Page403 = () => import('./pages/403.vue')
const Page500 = () => import('./pages/500.vue')
const Page418 = () => import('./pages/418.vue')

const Registration = () => import('./pages/Registration.vue')
const LoginCallback = () => import('./LoginCallback.vue')
const LogoutCallback = () => import('./LogoutCallback.vue')
const SilentCallback = () => import('./SilentCallback.vue')

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
  { path: '/admin', component: Admin, meta: {requiresAuth: true, role: 'Administrator'} },
  { path: '/resume/:id', component: Resume, meta: {requiresAuth: true, role: 'Teacher'} },
  { path: '/authentication/login-callback', component: LoginCallback },
  { path: '/authentication/logout-callback', component: LogoutCallback },
  { path: '/authentication/silent-callback', component: SilentCallback },
  { path: "/404", component: Page404 },
  { path: "/403", component: Page403 },
  { path: "/500", component: Page500 },
  { path: "/418", component: Page418 },
  { path: '/registration', component: Registration },
  { path: "/:catchAll(.*)", component: Page404 },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  }
})

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth) {
    userManager.getUser().then(async user => {
      if (!user || user.expired) {
        login();
      }
      else if (await role() !== to.meta.role)
        router.push('/403');
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
