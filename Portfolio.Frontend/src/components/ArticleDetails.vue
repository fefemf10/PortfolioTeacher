<script setup lang="ts">
  import { NFlex, NGrid, NText, NGi} from 'naive-ui';
  import MyNCard from '@/components/MyNCard.vue';
  import { Article } from '@/classes/Publication';
  import FileManager from '@/components/FileManager.vue';
  import { useI18n } from 'vue-i18n';
  const props = defineProps<{
    selected: Article
    loading: boolean
  }>();
  const {t} = useI18n();
</script>
<template>
  <MyNCard :title="selected.name">
      <NGrid responsive="screen" cols="3 s:12" x-gap="0" y-gap="12">
        <NGi span="3 s:3">
          <NText strong>{{ t('Common.CoAuthors') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NFlex vertical>
            <NText v-for="author of selected.coAuthors">{{author.lastName}} {{author.firstName}} {{author.middleName}}</NText>
          </NFlex>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.2') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.journal }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.3') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.yearPublication }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.4') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.beginPage }} - {{ selected.endPage }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.5') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.issueNumber }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.6') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.printedSheets }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Articles.DataColumns.7') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.url }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Common.Files') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <FileManager :loading="loading"></FileManager>
        </NGi>
      </NGrid>
    </MyNCard>
</template>
