<script setup lang="ts">
  import {NButton, NResult, NFlex} from 'naive-ui'
  import { useI18n } from 'vue-i18n';
  const { t } = useI18n();
</script>
<template>
  <NFlex justify="center" align="center" style="height: 100vh">
    <NResult size="huge" status="403" :title="t('Pages.403.title')" :description="t('Pages.403.description')">
      <template #footer>
        <NButton>{{ t('Pages.403.button') }}</NButton>
      </template>
    </NResult>
  </NFlex>
</template>
