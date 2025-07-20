import { createWebHistory, createRouter, RouteRecordRaw } from 'vue-router'
import userManager, { login, role } from './oidc.js'
const pages = import.meta.glob('./pages/**/*.vue')
function lazy(page) {
  const path = `./pages/${page}.vue`;
  const loader = pages[path];
  return loader;
}
const Home = lazy('Home')
const Dean = lazy('Dean')
const Deputy = lazy('Deputy')
const Stats = lazy('Stats')
const Admin = lazy('Admin')

const Resume = lazy('Resume/Resume')
const ResumeShort = lazy('Resume/Short')
const ResumeAwards = lazy('Resume/Awards')
const ResumeDisciplines = lazy('Resume/Disciplines')
const ResumeDissertations = lazy('Resume/Dissertations')
const ResumeProfessionalDevelopments = lazy('Resume/ProfessionalDevelopments')
const ResumePublicActivities = lazy('Resume/PublicActivities')
const ResumeMonographies = lazy('Resume/Monographies')
const ResumeTheses = lazy('Resume/Theses')
const ResumeArticles= lazy('Resume/Articles')
const ResumeScienceProjects = lazy('Resume/ScienceProjects')
const ResumeUniversities = lazy('Resume/Universities')
const ResumeWorks = lazy('Resume/Work')

const Me = lazy('Me/Me')
const MeShort = lazy('Me/Short')
const MeAwards = lazy('Me/Awards')
const MeDisciplines = lazy('Me/Disciplines')
const MeDissertations = lazy('Me/Dissertations')
const MeProfessionalDevelopments = lazy('Me/ProfessionalDevelopments')
const MePublicActivities = lazy('Me/PublicActivities')
const MeMonographies = lazy('Me/Monographies')
const MeTheses = lazy('Me/Theses')
const MeArticles= lazy('Me/Articles')
const MeScienceProjects = lazy('Me/ScienceProjects')
const MeUniversities = lazy('Me/Universities')
const MeWorks = lazy('Me/Work')

const Page404 = lazy('System/404')
const Page403 = lazy('System/403')
const Page500 = lazy('System/500')
const Page418 = lazy('System/418')
const Registration = lazy('System/Registration')

const LoginCallback = lazy('System/LoginCallback')
const LogoutCallback = lazy('System/LogoutCallback')

const routes:RouteRecordRaw[] = [
  { path: '/', component: Home },
  { path: '/dean', component: Dean },
  { path: '/deputy', component: Deputy },
  { path: '/stats', component: Stats },
  { path: '/admin', component: Admin, meta: {requiresAuth: true, role: 'Administrator'} },
  { path: '/resume/:id', component: Resume,
    children: [
      { path: '', component: ResumeShort },
      { path: 'awards', component: ResumeAwards },
      { path: 'disciplines', component: ResumeDisciplines },
      { path: 'dissertations', component: ResumeDissertations },
      { path: 'professionalDevelopments', component: ResumeProfessionalDevelopments },
      { path: 'publicActivities', component: ResumePublicActivities },
      { path: 'monographies/:eid?', component: ResumeMonographies },
      { path: 'theses', component: ResumeTheses },
      { path: 'articles', component: ResumeArticles },
      { path: 'scienceProjects', component: ResumeScienceProjects },
      { path: 'universities', component: ResumeUniversities },
      { path: 'works', component: ResumeWorks }
    ]
  },
  { path: '/me', component: Me, meta: {requiresAuth: false},
    children: [
      { path: '', component: MeShort },
      { path: 'awards', component: MeAwards },
      { path: 'disciplines', component: MeDisciplines },
      { path: 'dissertations', component: MeDissertations },
      { path: 'professionalDevelopments', component: MeProfessionalDevelopments },
      { path: 'publicActivities', component: MePublicActivities },
      { path: 'monographies/:eid?', component: MeMonographies },
      { path: 'theses', component: MeTheses },
      { path: 'articles', component: MeArticles },
      { path: 'scienceProjects', component: MeScienceProjects },
      { path: 'universities', component: MeUniversities },
      { path: 'works', component: MeWorks }
    ]
  },
  { path: '/authentication/login-callback', component: LoginCallback },
  { path: '/authentication/logout-callback', component: LogoutCallback },
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
    if (to.hash) {
      return {
        behavior: 'auto',
      }
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
