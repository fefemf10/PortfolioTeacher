<script setup lang="ts">
  import {NButton, NResult, NFlex} from 'naive-ui'
  import { useI18n } from 'vue-i18n';
  const { t } = useI18n();
</script>
<template>
  <NFlex justify="center" align="center" style="height: 100vh">
    <NResult size="huge" status="404" :title="t('Pages.404.title')" :description="t('Pages.404.description')">
      <template #footer>
        <NButton>{{ t('Pages.404.button') }}</NButton>
      </template>
    </NResult>
  </NFlex>
</template>
