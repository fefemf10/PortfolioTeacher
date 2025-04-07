<script setup lang="ts">
  import { UserProfile } from '../classes/userProfile';
  import UserInfo from '../components/UserInfo.vue';
  const user=new UserProfile();
  user.lastName="Терентьева";
  user.firstName="Татьяна";
  user.middleName="Валерьевна";
  user.academicDegree="Доктор экономических наук";
  user.academicTitle="Профессор";
  user.post="Ректор Кафедра экономики и управления, Профессор";
  user.phone="+79591112233";
  user.email="Dean0@yandex.ru";
  user.aud="ауд.Приемная";
</script>
<template>
  <UserInfo :user=user></UserInfo>
</template>
