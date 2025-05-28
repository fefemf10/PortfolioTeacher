<script setup lang="ts">
  import { NDataTable } from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink, useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { Article } from '@/classes/Publication';
  import ArticleDetails from '@/components/ArticleDetails.vue';
  const route = useRoute();
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
  const selected = computed<Article>(() => {
    return data.value.find(e => e.id === route.params.eid);
  });
  onMounted(async () => {
    data.value = await api.get<Article[]>(`api/teacher/${route.params.id}/publication/article`).json();
  });
</script>
<template>
  <MyNCard v-if=!route.params.eid :title="t('Pages.Resume.Articles.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered />
  </MyNCard>
  <ArticleDetails v-if="route.params.eid && selected" :selected="selected" :loading="false"></ArticleDetails>
  <MyNCard v-if="route.params.eid && !selected" title="Такой статьи нет">

  </MyNCard>
</template>
