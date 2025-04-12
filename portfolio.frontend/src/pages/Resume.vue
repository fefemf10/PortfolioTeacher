<script setup lang="ts">
import { NFlex } from 'naive-ui';
import { ref, onMounted } from 'vue';
import { UserProfile } from '../classes/UserProfile';
import NavMenu from '../components/NavMenu.vue';
import UserInfo from '../components/UserInfo.vue';
import CardResume from '../components/CardResume.vue';
import api from '../api';
onMounted(async() =>{
  try {
      const data = await api.get('api/faculty').json();
      console.log(data);
    } catch (error) {
      console.error('Ошибка API:', error);
    }
});
const user = new UserProfile();
user.lastName = "Терентьева";
user.firstName = "Татьяна";
user.middleName = "Валерьевна";
user.academicDegree = "Доктор экономических наук";
user.academicTitle = "Профессор";
user.post = "Ректор Кафедра экономики и управления, Профессор";
user.phone = "+79591112233";
user.email = "Dean0@yandex.ru";
user.aud = "ауд.Приемная";
</script>
<template>
  <NFlex justify="center" vertical style="gap: 1rem;">
    <UserInfo :user=user></UserInfo>
    <NavMenu></NavMenu>
    <CardResume/>
    <CardResume/>
    <CardResume/>
    <CardResume/>
    <CardResume/>
  </NFlex>
</template>
