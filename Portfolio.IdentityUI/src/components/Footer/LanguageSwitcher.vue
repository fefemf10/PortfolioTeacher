<script setup lang="ts">
import { ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { NDropdown, NButton } from 'naive-ui';

const { locale, t } = useI18n();

const options = ref([
  {
    label: 'English',
    key: 'en'
  },
  {
    label: 'Русский',
    key: 'ru'
  }
]);

function changeLocale(lang: string) {
  locale.value = lang;
  localStorage.setItem('locale', lang);
  document.documentElement.lang = lang;
}
</script>
<template>
  <NDropdown trigger="click" :options="options" @select="changeLocale">
    <NButton secondary>{{ t('Common.Lang') }}</NButton>
  </NDropdown>
</template>
