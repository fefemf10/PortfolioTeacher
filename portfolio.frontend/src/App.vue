<script setup lang="ts">
  import { NLayout, NLayoutContent, NLayoutHeader, NLayoutFooter, NText } from 'naive-ui'
  import { RouterView } from 'vue-router'
  import ThemeSwitcher from './ThemeSwitcher.vue';
</script>
<template>
  <NLayout>
    <NLayoutHeader class="headfoot">
      <NText>ДонГТУ</NText>
      <ThemeSwitcher />
    </NLayoutHeader>
    <NLayoutContent content-style="min-height: calc(100dvh - 6rem); padding: 1rem; min-width: 320px;">
        <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
      <NText>&copy; Алдакимов Д. А., 2025</NText>
    </NLayoutFooter>
  </NLayout>
</template>
<style scoped>
  .routerview {
    padding: 0 1rem; min-width: calc(200px + 4rem);
  }
  .headfoot{
    font-size: large;
    font-weight: bold;
    display:flex;
    text-wrap-mode: nowrap;
    justify-content:center;
    align-items: center;
    height: 3rem;
    padding: 0 1rem;
  }
</style>
