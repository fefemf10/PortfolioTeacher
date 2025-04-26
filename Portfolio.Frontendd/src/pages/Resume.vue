<script setup lang="ts">
import { NFlex } from 'naive-ui';
import { onMounted, ref } from 'vue';
import { UserProfile } from '../classes/UserProfile';
import NavMenu from '../components/NavMenu.vue';
import UserInfo from '../components/UserInfo.vue';
import CardResume from '../components/CardResume.vue';
import api from '../api';
import {useRoute} from 'vue-router'
import { ShortCardItem } from '../classes/ShortCardItem';
import { TeacherShortInfo } from '../classes/TeacherShortInfo';
const route = useRoute();
const user = ref<UserProfile>(null);
const userShort = ref<TeacherShortInfo>(new TeacherShortInfo());
onMounted(async() =>{
    user.value = await api.get<UserProfile>('api/teacher/' + route.params.id).json();
    userShort.value = await api.get<TeacherShortInfo[]>('api/teacher/' + route.params.id + '/short').json();
});
</script>
<template>
  <NFlex justify="center" vertical style="gap: 1rem;">
    <UserInfo v-if="user" :user=user></UserInfo>
    <NavMenu></NavMenu>
    <CardResume v-if="userShort" title="Образование" :items="userShort.universities" />
    <CardResume v-if="userShort" title="Работа" :items="userShort.works" />
    <CardResume v-if="userShort" title="Научные проекты" :items="userShort.scienceProjects" />
    <CardResume v-if="userShort" title="Научные проекты" :items="userShort.professionalDevelopments" />
    <CardResume v-if="userShort" title="Научные проекты" :items="userShort.awards" />
  </NFlex>
</template>
