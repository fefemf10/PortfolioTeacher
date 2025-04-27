<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Dissertation } from '@/classes/Dissertation';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Dissertation[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Dissertations.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.1'),
        key: 'yearProtection'
      },
  ]);
  onMounted(async () => {
    data.value = await api.get<Dissertation[]>(`api/teacher/${route.params.id}/dissertation`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Dissertations.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
