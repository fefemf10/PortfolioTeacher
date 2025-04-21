<script setup lang="ts">
  import {NButton, NResult, NFlex} from 'naive-ui'
  import { useI18n } from 'vue-i18n';
  const { t } = useI18n();
</script>
<template>
  <NFlex justify="center" align="center">
    <NResult size="huge" status="500" :title="t('Pages.500.title')" :description="t('Pages.500.description')">
      <template #footer>
        <NButton>{{ t('Pages.500.button') }}</NButton>
      </template>
    </NResult>
  </NFlex>
</template>
