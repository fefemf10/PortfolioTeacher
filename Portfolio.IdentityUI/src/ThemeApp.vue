<script setup lang="ts">
import { NConfigProvider, NMessageProvider } from 'naive-ui'
import { useThemeStore } from './ThemeStore'
import App from './App.vue'
const { naiveTheme } = useThemeStore()
</script>
<template>
  <NConfigProvider :theme="naiveTheme">
      <NMessageProvider>
          <App />
      </NMessageProvider>
  </NConfigProvider>
</template>
