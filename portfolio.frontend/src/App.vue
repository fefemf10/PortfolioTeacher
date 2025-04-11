<script setup lang="ts">
  import { MenuOption, NButton, NLayout, NLayoutContent, NLayoutSider, NMenu, NIcon, NFlex } from 'naive-ui'
  import { useI18n } from 'vue-i18n'
  import { Component, h, ref, watch } from 'vue';
  import { RouterLink, useRoute } from 'vue-router'
  import LanguageSwitcher from './components/LanguageSwitcher.vue';
  import { logout } from './oidc';
  const route = useRoute()
  const { t } = useI18n()
  const activeKey = ref(route.path)
  watch(
    () => route.path,
    (newPath) => {
      activeKey.value = newPath
    }
  )
</script>
<template>
  <NLayout>
    <NLayoutContent style="height: 100vh; background-color: #f5f5f5;" content-style="padding: 0 15px; max-width: 80vw; margin: 0 auto; min-width: calc(230px + 2rem);">
        <RouterView />
    </NLayoutContent>
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
</style>
