<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { ScienceProject } from '@/classes/ScienceProject';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<ScienceProject[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.ScienceProjects.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.ScienceProjects.DataColumns.1'),
        key: 'beginTimeWork'
      },
      {
        title: t('Pages.Resume.ScienceProjects.DataColumns.2'),
        key: 'endTimeWork'
      },
      {
        title: t('Pages.Resume.ScienceProjects.DataColumns.3'),
        key: 'director'
      },
  ]);
  onMounted(async () => {
    data.value = await api.get<ScienceProject[]>(`api/teacher/${route.params.id}/scienceProject`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.ScienceProjects.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
