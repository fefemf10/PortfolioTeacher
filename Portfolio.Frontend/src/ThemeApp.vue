<script setup lang="ts">
import { NConfigProvider, NDialogProvider, NMessageProvider } from 'naive-ui'
import { useThemeStore } from './ThemeStore'
import App from './App.vue'
const { naiveTheme } = useThemeStore()
</script>
<template>
  <NConfigProvider :theme="naiveTheme">
    <NDialogProvider>
      <NMessageProvider>
        <App />
      </NMessageProvider>
    </NDialogProvider>
  </NConfigProvider>
</template>
