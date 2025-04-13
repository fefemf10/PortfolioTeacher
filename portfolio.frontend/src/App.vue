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
    <NLayoutContent style="min-height: calc(100dvh - 6rem);" content-style="padding: 0 1rem; max-width: 80vw; margin: 0 auto; min-width: calc(200px + 4rem);">
        <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
      <NText>&copy; Алдакимов Д. А., 2025</NText>
    </NLayoutFooter>
  </NLayout>
</template>
<style scoped>
  .routerview {
    padding: 0 15px; max-width: 80svw; margin: 0 auto; min-width: 200px;
  }
  .headfoot{
    font-size: large;
    font-weight: bold;
    display:flex; flex-wrap: nowrap; text-wrap-mode: nowrap; justify-content:center; align-items: center; height: 3rem; background-color: inherit; padding: 0 1rem; max-width: 80vw; margin: 0 auto;
  }
</style>
