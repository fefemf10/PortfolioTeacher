<script setup lang="ts">
  import {NFlex, NText} from 'naive-ui'
  import NavigableBlock from '../components/NavigableBlock.vue'
  import CardUser from '../components/Home/CardUser.vue';
  import { UserProfile } from '../classes/UserProfile';
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
  <NFlex class="roothome" justify="space-between" size="large">
      <CardUser class="users" :user=user />
      <NavigableBlock class="navblock"/>
  </NFlex>
</template>
<style scoped>
  .users {
    width: calc(100% - 23rem);
    flex-shrink: 0;
    flex-grow: 1;
  }
  .navblock {
    width: 20rem;
    flex-grow: 1;
  }
</style>
