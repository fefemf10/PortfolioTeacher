<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { Article } from '@/classes/Publication';
  import { guid } from '@/oidc';
  const {t} = useI18n();
  const data = ref<Article[]>([]);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Articles.DataColumns.0'),
        key: 'coAuthors',
        render: (row: Article) => {
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
        title: t('Pages.Resume.Articles.DataColumns.1'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Articles.DataColumns.2'),
        key: 'journal'
      },
      {
        title: t('Pages.Resume.Articles.DataColumns.3'),
        key: 'yearPublication'
      }
  ]);
  onMounted(async () => {
    data.value = await api.get<Article[]>(`api/teacher/${await guid()}/publication/article`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Articles.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
</template>
