<script setup lang="ts">
import ResumeShortCard from '@/components/Resume/ResumeShortCard.vue';
import { TeacherShortInfo } from '@/classes/TeacherShortInfo';
import { onMounted, ref } from 'vue'
import api from '@/api';
import { guid } from '@/oidc';
const userShort = ref<TeacherShortInfo>(null);
  onMounted(async() => {
    userShort.value = await api.get<TeacherShortInfo>(`api/teacher/${await guid()}/short`).json();
});
</script>
<template>
  <ResumeShortCard v-if="userShort" title="Образование" :items="userShort.universities" />
  <ResumeShortCard v-if="userShort" title="Работа" :items="userShort.works" />
  <ResumeShortCard v-if="userShort" title="Научные проекты" :items="userShort.scienceProjects" />
  <ResumeShortCard v-if="userShort" title="Повышения квалификации" :items="userShort.professionalDevelopments" />
  <ResumeShortCard v-if="userShort" title="Награды" :items="userShort.awards" />
</template>
