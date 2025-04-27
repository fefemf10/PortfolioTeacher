<script setup lang="ts">
import { NConfigProvider } from 'naive-ui'
import { useThemeStore } from './ThemeStore'
import App from './App.vue'
const { naiveTheme } = useThemeStore()
</script>
<template>
  <NConfigProvider :theme="naiveTheme">
    <App />
  </NConfigProvider>
</template>
