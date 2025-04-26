<script setup lang="ts">
  import { NFlex, NCard } from 'naive-ui'
  import { UserProfile } from '../classes/UserProfile';
  import NavMenu from '../components/NavMenu.vue';
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
  <NFlex justify="center" vertical>
    <UserInfo :user=user></UserInfo>
    <NavMenu></NavMenu>
    <NCard class="cards" title="Образование">
      <template #footer>
        #footer
      </template>
    </NCard>
  </NFlex>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
  }
</style>
