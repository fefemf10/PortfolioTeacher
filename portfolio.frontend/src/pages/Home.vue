<script setup lang="ts">
  import {NFlex} from 'naive-ui'
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
  <NFlex justify="space-between" :size="[0, 0]" style="min-width: 20rem;">
    <NFlex class="users">
      <CardUser :user=user />
    </NFlex>
    <NFlex class="navblock">
      <NavigableBlock/>
    </NFlex>
  </NFlex>
</template>
<style scoped>
  .users{
  }
  .navblock{
    width: 20rem;
  }
</style>
