import { fileURLToPath, URL } from 'node:url';
import { resolve, dirname } from 'node:path';
import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import VueI18nPlugin from '@intlify/unplugin-vue-i18n/vite'
import { createHtmlPlugin } from 'vite-plugin-html'
import { env } from 'process';

// https://vitejs.dev/config/
export default defineConfig({
  base: '/id/',
  plugins: [
    createHtmlPlugin({}),
    plugin(),
    VueI18nPlugin({
      /* options */
      // locale messages resource pre-compile option
      include: resolve(dirname(fileURLToPath(import.meta.url)), './src/locales/**'),
    }),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    port: parseInt(env.DEV_SERVER_PORT || '10001'),
  }
})
