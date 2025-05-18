<script setup lang="ts">
import ResumeShortCard from '@/components/Resume/ResumeShortCard.vue';
import { TeacherShortInfo } from '@/classes/TeacherShortInfo';
import { onMounted, ref } from 'vue'
import api from '@/api';
import { guid } from '@/oidc';
import { useI18n } from 'vue-i18n';
const userShort = ref<TeacherShortInfo>(null);
const { t } = useI18n();
  onMounted(async() => {
    userShort.value = await api.get<TeacherShortInfo>(`api/teacher/${await guid()}/short`).json();
});
</script>
<template>
  <ResumeShortCard v-if="userShort" :title="t('Pages.Resume.University.NameTitle')" :items="userShort.universities" />
  <ResumeShortCard v-if="userShort" :title="t('Pages.Resume.Work.NameTitle')" :items="userShort.works" />
  <ResumeShortCard v-if="userShort" :title="t('Pages.Resume.ScienceProjects.NameTitle')" :items="userShort.scienceProjects" />
  <ResumeShortCard v-if="userShort" :title="t('Pages.Resume.ProfessionalDevelopments.NameTitle')" :items="userShort.professionalDevelopments" />
  <ResumeShortCard v-if="userShort" :title="t('Pages.Resume.Awards.NameTitle')" :items="userShort.awards" />
</template>
