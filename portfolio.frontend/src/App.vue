<script setup lang="ts">
  import { NLayout, NLayoutContent, NLayoutHeader, NLayoutFooter, NText } from 'naive-ui'
  import { RouterView } from 'vue-router'
</script>
<template>
  <NLayout style="background-color: #f5f5f5;">
    <NLayoutHeader class="headfoot">
      <NText>ДонГТУ</NText>
    </NLayoutHeader>
    <NLayoutContent style="min-height: calc(100vh - 6rem); background-color: inherit;" content-style="padding: 0 15px; max-width: 80vw; margin: 0 auto; min-width: calc(230px + 2rem);">
        <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
      <NText>&copy; Алдакимов Д. А., 2025</NText>
    </NLayoutFooter>
  </NLayout>
</template>
<style scoped>
  .LayoutContent {
    background-color: #f5f5f5;
    width: 100%;
  }
  .routerview {
    padding: 0 15px; max-width: 80svw; margin: 0 auto; min-width: 200px;
  }
  .headfoot{
    font-size: large;
    font-weight: bold;
    display:flex; flex-wrap: nowrap; text-wrap-mode: nowrap; justify-content:center; align-items: center; height: 3rem; background-color: inherit; padding: 0 15px; max-width: 80vw; margin: 0 auto;
  }
</style>
