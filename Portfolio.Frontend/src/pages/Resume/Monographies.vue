<script setup lang="ts">
  import { NDataTable, NFlex, NP, NButton, NSpace, NGrid, NGi, NText } from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink, useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { Monography } from '@/classes/Publication';
  import router from '@/Router';
  import FileManager from '@/components/FileManager.vue';
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
  const selected = computed<Monography>(() => {
    return data.value.find(e => e.id === route.params.eid);
  });
  onMounted(async () => {
    data.value = await api.get<Monography[]>(`api/teacher/${route.params.id}/publication/monography`).json();
  });
  const rowProps = (row: Monography) => ({
    style: {
      cursor: 'pointer',
    },
    onClick: () => {
      router.push(`/resume/${route.params.id}/monographies/${row.id}`);
    }
  });

</script>
<template>
  <MyNCard v-if=!route.params.eid :title="t('Pages.Resume.Monographies.CardTitle')">
    <NDataTable :columns="columns" :data="data" bordered :row-props="rowProps" />
  </MyNCard>
  <MyNCard v-if="route.params.eid && selected" :title="selected.name">
      <!-- Авторы -->
      <NGrid responsive="screen" cols="3 s:12" x-gap="0" y-gap="12">
        <NGi span="3 s:3">
          <NText strong>Авторы ВВГУ</NText>
        </NGi>
        <NGi span="9 s:9">
          <NFlex vertical>
            <NText v-for="author of selected.coAuthors">{{author.lastName}} {{author.firstName}} {{author.middleName}}</NText>
          </NFlex>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>Издательство:</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>ВВГУ</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>Год издания:</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>2022</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>Страницы:</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>144</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>Тираж:</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>500 экз.</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>Файлы:</NText>
        </NGi>
        <NGi span="9 s:9">
          <NFlex vertical>
            <NFlex nowrap v-for="file of selected.files">
              <NButton ghost type="error" strong size="small">{{file.fileType.toString()}}</NButton>
              <RouterLink :to="`/files/${file.id}`"><NButton ghost type="error" strong size="small">{{ file.name }}</NButton></RouterLink>
              <NText depth="3">{{ file.size % 1024 % 1024 }} Mb</NText>
            </NFlex>
          </NFlex>
        </NGi>
        <FileManager></FileManager>
      </NGrid>
  </MyNCard>
  <MyNCard v-if="route.params.eid && !selected" title="Такой монографии нет">

  </MyNCard>
</template>
