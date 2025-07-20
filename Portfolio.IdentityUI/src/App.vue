<script setup lang="ts">
  import { NLayout, NLayoutContent, NLayoutFooter } from 'naive-ui'
  import { RouterView } from 'vue-router'
  import ThemeSwitcher from '@/components/Footer/ThemeSwitcher.vue';
  import LanguageSwitcher from '@/components/Footer/LanguageSwitcher.vue';
</script>
<template>
  <NLayout>
    <NLayoutContent content-style="min-height: calc(100dvh - 3rem); padding: 1rem; min-width: 320px;">
      <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
      <ThemeSwitcher />
      <LanguageSwitcher />
    </NLayoutFooter>
  </NLayout>
</template>
<style scoped>
  .headfoot{
    font-size: large;
    font-weight: bold;
    display:flex;
    text-wrap-mode: nowrap;
    justify-content: space-between;
    align-items: center;
    height: 3rem;
    padding: 0 1rem;
  }
</style>
