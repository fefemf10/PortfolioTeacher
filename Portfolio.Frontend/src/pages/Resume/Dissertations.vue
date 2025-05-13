<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { Dissertation } from '@/classes/Dissertation';
  import { computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import { useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { DissertationType } from '@/enums/DissertationType';
  import { useEnumLocalization } from '@/EnumLocalization';
  const route = useRoute();
  const {t} = useI18n();
  const { localizeEnum } = useEnumLocalization();
  const data = ref<Dissertation[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Dissertations.DataColumns.0'),
        key: 'yearProtection'
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.1'),
        key: 'type',
        render: (row: Dissertation) => localizeEnum(row.type, DissertationType, 'Dissertation')
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.2'),
        key: 'specialization'
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.3'),
        key: 'topic'
      }
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
