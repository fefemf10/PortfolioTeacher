import { createApp } from 'vue'
import router from './Router';
import App from './App.vue'
import i18n from './i18n'
createApp(App).use(i18n).use(router).mount('#app')
