<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Discipline } from '@/classes/Discipline';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Discipline[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Disciplines.DataColumns.0'),
        key: 'name'
      }
  ]);
  onMounted(async () => {
    data.value = await api.get<Discipline[]>(`api/teacher/${route.params.id}/discipline`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Disciplines.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
