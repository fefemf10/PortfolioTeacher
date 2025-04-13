<script setup lang="ts">
import { NConfigProvider, NThemeEditor } from 'naive-ui'
import { useThemeStore } from './ThemeStore'
import App from './App.vue'
const { naiveTheme } = useThemeStore()
</script>
<template>
  <NThemeEditor>
    <NConfigProvider :theme="naiveTheme">
      <App />
    </NConfigProvider>
  </NThemeEditor>
</template>
