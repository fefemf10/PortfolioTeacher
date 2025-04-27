<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Publication } from '@/classes/Publication';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Publication[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Publications.DataColumns.0'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Publications.DataColumns.1'),
        key: 'form'
      },
      {
        title: t('Pages.Resume.Publications.DataColumns.2'),
        key: 'outputData'
      },
      {
        title: t('Pages.Resume.Publications.DataColumns.3'),
        key: 'size'
      },
      {
        title: t('Pages.Resume.Publications.DataColumns.4'),
        key: 'coAuthor'
      }
  ]);
  onMounted(async () => {
    data.value = await api.get<Publication[]>(`api/teacher/${route.params.id}/publication`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Publications.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
