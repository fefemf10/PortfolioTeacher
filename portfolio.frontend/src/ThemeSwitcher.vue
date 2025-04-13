<script setup lang="ts">
  import { ref, watch } from 'vue'
  import { NRadioGroup, NRadioButton, NSpace } from 'naive-ui'
  import { useThemeStore } from './ThemeStore';
  const { themePreference } = useThemeStore()
</script>
<template>
  <NSpace align="center" style="padding: 1rem;">
    <NRadioGroup v-model:value="themePreference">
      <NRadioButton value="system">🌗 Системная</NRadioButton>
      <NRadioButton value="light">☀️ Светлая</NRadioButton>
      <NRadioButton value="dark">🌙 Тёмная</NRadioButton>
    </NRadioGroup>
  </NSpace>
</template>

