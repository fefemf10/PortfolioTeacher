<script setup lang="ts">
import { NConfigProvider, NDialogProvider, NMessageProvider, NNotificationProvider } from 'naive-ui'
import { useThemeStore } from './ThemeStore'
import App from './App.vue'
const { naiveTheme } = useThemeStore()
</script>
<template>
  <NConfigProvider :theme="naiveTheme">
    <NDialogProvider>
      <NMessageProvider>
        <NNotificationProvider>
          <App />
        </NNotificationProvider>
      </NMessageProvider>
    </NDialogProvider>
  </NConfigProvider>
</template>
