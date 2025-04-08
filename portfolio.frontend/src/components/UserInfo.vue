<script setup lang="ts">
  import { UserProfile } from '../classes/UserProfile';
  import {NFlex, NAvatar, NDivider } from 'naive-ui'
  import UserNameInfo from './UserNameInfo.vue';
  import UserDetailsInfo from './UserDetailsInfo.vue';
  const props = defineProps<{
    user: UserProfile
  }>()
</script>
<template>
  <NFlex class="UserInfoCard" justify="space-evenly" align="center" reverse>
    <NAvatar circle :size="200" src="https://avatar.iran.liara.run/public" />
    <NFlex vertical>
      <UserNameInfo :lastName=user.lastName :firstName=user.firstName :middleName=user.middleName :academicDegree=user.academicDegree :academicTitle=user.academicTitle />
      <NDivider class="divider"/>
      <UserDetailsInfo :post=user.post :email=user.email :phone=user.phone :aud=user.aud />
    </NFlex>
  </NFlex>
</template>
<style scoped>
  .divider{
    background-color: red;
    height: 2px;
    margin: 0;
  }
  .UserInfoCard{
    background-color: white;
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
    padding: 1rem;
  }
</style>
