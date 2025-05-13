<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { ProfessionalDevelopment } from '@/classes/ProfessionalDevelopment';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { guid } from '@/oidc';
  const {t} = useI18n();
  const data = ref<ProfessionalDevelopment[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.1'),
        key: 'nameOrganization'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.2'),
        key: 'nameDocument'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.3'),
        key: 'seriaDocument'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.4'),
        key: 'numberDocument'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.5'),
        key: 'dateСompletion'
      },
      {
        title: t('Pages.Resume.ProfessionalDevelopments.DataColumns.6'),
        key: 'listeningTime'
      }
  ]);
  onMounted(async () => {
    data.value = await api.get<ProfessionalDevelopment[]>(`api/teacher/${await guid()}/professionalDevelopment`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.ProfessionalDevelopments.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
