<script setup lang="ts">
  import { NFlex, NGrid, NText, NGi} from 'naive-ui';
  import MyNCard from '@/components/MyNCard.vue';
  import { Monography } from '@/classes/Publication';
  import FileManager from '@/components/FileManager.vue';
  import { useI18n } from 'vue-i18n';
  import { useRoute } from 'vue-router';
  const route = useRoute();
  const props = defineProps<{
    selected: Monography
    loading: boolean
  }>();
  const {t} = useI18n();
</script>
<template>
  <MyNCard :title="selected.name">
      <!-- Авторы -->
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
          <NText strong>{{ t('Pages.Resume.Monographies.DataColumns.2') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.publisher }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Monographies.DataColumns.3') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.yearPublication }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Monographies.DataColumns.4') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.circulation }}</NText>
        </NGi>
        <NGi span="3 s:3">
          <NText strong>{{ t('Pages.Resume.Monographies.DataColumns.5') }}</NText>
        </NGi>
        <NGi span="9 s:9">
          <NText>{{ selected.countPages }}</NText>
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
