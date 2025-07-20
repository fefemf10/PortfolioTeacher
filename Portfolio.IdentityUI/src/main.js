import { createApp } from 'vue'
import router from '@/Router';
import ThemeApp from '@/ThemeApp.vue';
import i18n from '@/i18n';

createApp(ThemeApp).use(i18n).use(router).mount('#app')
