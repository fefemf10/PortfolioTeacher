<script setup lang="ts">
  import { NRadioGroup, NRadioButton, NFlex } from 'naive-ui'
  import { useThemeStore } from '@/ThemeStore';
  const { themePreference } = useThemeStore()
</script>
<template>
  <NFlex align="center" style="padding: 0 1rem;">
    <NRadioGroup v-model:value="themePreference">
      <NRadioButton value="system">🌗</NRadioButton>
      <NRadioButton value="light">☀️</NRadioButton>
      <NRadioButton value="dark">🌙</NRadioButton>
    </NRadioGroup>
  </NFlex>
</template>

