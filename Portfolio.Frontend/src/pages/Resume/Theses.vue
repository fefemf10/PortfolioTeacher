<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink, useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { Thesis } from '@/classes/Publication';
import ThesisDetails from '@/components/ThesisDetails.vue';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Thesis[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Theses.DataColumns.0'),
        key: 'coAuthors',
        render: (row: Thesis) => {
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
        title: t('Pages.Resume.Theses.DataColumns.1'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Theses.DataColumns.2'),
        key: 'collection'
      },
      {
        title: t('Pages.Resume.Theses.DataColumns.3'),
        key: 'yearPublication'
      }
  ]);
  const selected = computed<Thesis>(() => {
    return data.value.find(e => e.id === route.params.eid);
  });
  onMounted(async () => {
    data.value = await api.get<Thesis[]>(`api/teacher/${route.params.id}/publication/thesis`).json();
  });
</script>
<template>
  <MyNCard v-if=!route.params.eid :title="t('Pages.Resume.Theses.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
  <ThesisDetails v-if="route.params.eid && selected" :selected="selected" :loading="false"></ThesisDetails>
  <MyNCard v-if="route.params.eid && !selected" title="Такого доклада нет">

  </MyNCard>
</template>
