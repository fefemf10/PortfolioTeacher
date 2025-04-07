<script setup lang="ts">
  import {NFlex, NAvatar, NDivider } from 'naive-ui'
  import UserNameInfo from './UserNameInfo.vue';
  import UserDetailsInfo from './UserDetailsInfo.vue';
  import { UserProfile } from '../classes/userProfile';
  const props = defineProps<{
    user: UserProfile
  }>()
</script>
<template>
  <NFlex justify="center" align="center" inline reverse>
    <NAvatar circle :size="200" src="https://avatar.iran.liara.run/public"></NAvatar>
    <NFlex vertical>
      <UserNameInfo :lastName=user.lastName :firstName=user.firstName :middleName=user.middleName :academicDegree=user.academicDegree :academicTitle=user.academicTitle />
      <NDivider class="divider"/>
      <UserDetailsInfo :post=user.post :email=user.email :phone=user.phone :aud=user.aud />
    </NFlex>
  </NFlex>
</template>
<style scoped>
  .divider{
    margin: 0;
  }
</style>
