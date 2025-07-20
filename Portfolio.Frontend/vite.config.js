import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import { resolve, dirname } from 'node:path'
import { fileURLToPath } from 'url'
import VueI18nPlugin from '@intlify/unplugin-vue-i18n/vite'
import { createHtmlPlugin } from 'vite-plugin-html'
import vueDevTools from 'vite-plugin-vue-devtools'
import { env } from 'process';

// https://vitejs.dev/config/
export default defineConfig({
    resolve:{
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
      }
    },
    plugins: [
      vueDevTools(),
      createHtmlPlugin({}),
      plugin(),
      VueI18nPlugin({
        /* options */
        // locale messages resource pre-compile option
        include: resolve(dirname(fileURLToPath(import.meta.url)), './src/locales/**'),
      }),
    ],
    server: {
        port: parseInt(env.DEV_SERVER_PORT || '10000'),
    }
})
