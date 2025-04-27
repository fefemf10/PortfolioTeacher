<script setup lang="ts">
  import { UserProfile } from '@/classes/UserProfile';
  import {NFlex, NAvatar, NDivider, DividerProps, useThemeVars } from 'naive-ui'
  import UserNameInfo from './UserNameInfo.vue';
  import UserDetailsInfo from './UserDetailsInfo.vue';
  import MyNCard from '@/components/MyNCard.vue';
  import { hashCode } from '@/hashCode';
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
  <MyNCard class="UserInfoCard">
    <NFlex justify="space-evenly" align="center" reverse>
      <NAvatar lazy circle :size="200" :src='`https://avatar.iran.liara.run/public/${hashCode(user.id) % 100}`' />
      <NFlex vertical>
        <UserNameInfo :lastName=user.lastName :firstName=user.firstName :middleName=user.middleName :academicDegree=user.academicDegree :academicTitle=user.academicTitle />
        <NDivider :theme-overrides="dividerThemeOverrides"/>
        <UserDetailsInfo :post=user.post :email=user.email :phone=user.phone aud="" />
      </NFlex>
    </NFlex>
  </MyNCard>
</template>
<style scoped>
  .n-divider{
    height: 2px;
    margin: 0;
  }
</style>
