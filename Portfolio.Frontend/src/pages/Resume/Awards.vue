<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Award } from '@/classes/Award';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Award[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Awards.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Awards.DataColumns.1'),
        key: 'nameOrganization'
      },
      {
        title: t('Pages.Resume.Awards.DataColumns.2'),
        key: 'dateAward'
      },
  ]);
  onMounted(async () => {
    data.value = await api.get<Award[]>(`api/teacher/${route.params.id}/award`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Awards.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
