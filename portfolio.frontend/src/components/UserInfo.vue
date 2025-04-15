<script setup lang="ts">
  import { UserProfile } from '../classes/UserProfile';
  import {NFlex, NAvatar, NDivider, DividerProps, useThemeVars } from 'naive-ui'
  import UserNameInfo from './UserNameInfo.vue';
  import UserDetailsInfo from './UserDetailsInfo.vue';
  import { ref } from 'vue';
  const props = defineProps<{
    user: UserProfile
  }>();
  type DividerThemeOverrides = NonNullable<DividerProps['themeOverrides']>
  const dividerThemeOverrides: DividerThemeOverrides = {
    color: 'red',
  }
  const themeVars = useThemeVars();
  const borderColor = themeVars.value.boxShadow1;
</script>
<template>
  <NFlex class="UserInfoCard" justify="space-evenly" align="center" reverse>
    <NAvatar lazy circle :size="200" src="https://avatar.iran.liara.run/public" />
    <NFlex vertical>
      <UserNameInfo :lastName=user.lastName :firstName=user.firstName :middleName=user.middleName :academicDegree=user.academicDegree :academicTitle=user.academicTitle />
      <NDivider :theme-overrides="dividerThemeOverrides"/>
      <UserDetailsInfo :post=user.post :email=user.email :phone=user.phone :aud=user.aud />
    </NFlex>
  </NFlex>
</template>
<style scoped>
  .n-divider{
    height: 2px;
    margin: 0;
  }
  .UserInfoCard{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
    padding: 1rem;
  }
</style>
