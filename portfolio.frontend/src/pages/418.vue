<script setup lang="ts">
  import {NButton, NResult, NFlex} from 'naive-ui'
  import { useI18n } from 'vue-i18n';
  const { t } = useI18n();
</script>
<template>
  <NFlex justify="center" align="center" style="height: 100vh">
    <NResult size="huge" status="418" :title="t('Pages.418.title')" :description="t('Pages.418.description')">
      <template #footer>
        <NButton>{{ t('Pages.418.button') }}</NButton>
      </template>
    </NResult>
  </NFlex>
</template>
