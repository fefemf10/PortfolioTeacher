<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink, useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { Monography } from '@/classes/Publication';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Monography[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Monographies.DataColumns.0'),
        key: 'coAuthors',
        render: (row: Monography) => {
          return row.coAuthors?.map(coAuthor => {
            const fullName = `${coAuthor.lastName} ${coAuthor.firstName} ${coAuthor.middleName}`;
            return h(
              RouterLink,
              {
                to: `/resume/${coAuthor.id}`
              },
              { default: () => fullName }
            );
          });
        }
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.1'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.2'),
        key: 'publisher'
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.3'),
        key: 'yearPublication'
      }
  ]);
  onMounted(async () => {
    data.value = await api.get<Monography[]>(`api/teacher/${route.params.id}/publication/monographies`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Monographies.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
