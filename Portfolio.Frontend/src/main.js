import { createApp } from 'vue';
import router from './Router';
import ThemeApp from './ThemeApp.vue';
import i18n from './i18n';
import { createPinia } from 'pinia';
const pinia = createPinia();
createApp(ThemeApp).use(i18n).use(router).use(pinia).mount('#app');
