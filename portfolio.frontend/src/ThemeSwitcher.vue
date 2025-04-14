<script setup lang="ts">
  import { ref, watch } from 'vue'
  import { NRadioGroup, NRadioButton, NSpace } from 'naive-ui'
  import { useThemeStore } from './ThemeStore';
  const { themePreference } = useThemeStore()
</script>
<template>
  <NSpace align="center" style="padding: 1rem;">
    <NRadioGroup v-model:value="themePreference">
      <NRadioButton value="system">🌗</NRadioButton>
      <NRadioButton value="light">☀️</NRadioButton>
      <NRadioButton value="dark">🌙</NRadioButton>
    </NRadioGroup>
  </NSpace>
</template>

