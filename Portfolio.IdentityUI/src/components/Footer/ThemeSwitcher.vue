<script setup lang="ts">
  import { NRadioGroup, NRadioButton, NFlex } from 'naive-ui'
  import { useThemeStore } from '@/ThemeStore';
  const { themePreference } = useThemeStore()
</script>
<template>
  <NFlex align="center" style="padding: 0 1rem;">
    <NRadioGroup v-model:value="themePreference">
      <NRadioButton id="system" name="system" value="system">🌗</NRadioButton>
      <NRadioButton id="light" name="light" value="light">☀️</NRadioButton>
      <NRadioButton id="dark" name="dark" value="dark">🌙</NRadioButton>
    </NRadioGroup>
  </NFlex>
</template>

