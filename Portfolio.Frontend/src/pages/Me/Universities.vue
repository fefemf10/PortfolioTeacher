<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { University } from '@/classes/University';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { guid } from '@/oidc';
  const {t} = useI18n();
  const data = ref<University[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.University.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.University.DataColumns.1'),
        key: 'specialization'
      },
      {
        title: t('Pages.Resume.University.DataColumns.2'),
        key: 'qualification'
      },
      {
        title: t('Pages.Resume.University.DataColumns.3'),
        key: 'yearGraduation'
      },
  ]);
  onMounted(async () => {
    data.value = await api.get<University[]>(`api/teacher/${await guid()}/university`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.University.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
