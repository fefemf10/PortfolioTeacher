<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Work } from '@/classes/Work';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Work[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Work.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Work.DataColumns.1'),
        key: 'post'
      },
      {
        title: t('Pages.Resume.Work.DataColumns.2'),
        key: 'beginTimeWork'
      },
      {
        title: t('Pages.Resume.Work.DataColumns.3'),
        key: 'endTimeWork'
      },
  ]);
  onMounted(async () => {
    data.value = await api.get<Work[]>(`api/teacher/${route.params.id}/work`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Work.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
