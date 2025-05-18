<script setup lang="ts">
  import { UserProfile } from '@/classes/UserProfile';
  import {NFlex, NAvatar, NDivider, DividerProps, useThemeVars, NUpload } from 'naive-ui'
  import UserNameInfo from './UserNameInfo.vue';
  import UserDetailsInfo from './UserDetailsInfo.vue';
  import MyNCard from '@/components/MyNCard.vue';
  import { hashCode } from '@/hashCode';
import { computed, onMounted, ref } from 'vue';
  const props = defineProps<{
    user: UserProfile,
    upload: boolean
  }>();
  type DividerThemeOverrides = NonNullable<DividerProps['themeOverrides']>
  const dividerThemeOverrides: DividerThemeOverrides = {
    color: 'red',
  }
  const themeVars = useThemeVars();
  const borderColor = themeVars.value.boxShadow1;
  const urlAvatar = ref<string>(null);
  onMounted(async () => {
    if (props.user.avatar)
      urlAvatar.value = `/api/user/${props.user.id}/avatar`;
    else
      urlAvatar.value = `https://avatar.iran.liara.run/public/${hashCode(props.user.id) % 100}`;
  });
  function onFinishedUpload(){
    const timestamp = new Date().getTime();
    urlAvatar.value = `/api/user/${props.user.id}/avatar?${timestamp}`;
  }
</script>
<template>
  <MyNCard class="UserInfoCard">
    <NFlex justify="space-evenly" align="center" reverse>
      <NFlex>
        <NUpload v-if="upload" :show-file-list=false @finish="onFinishedUpload"
          :action="`/api/user/${user.id}/avatar`">
          <NAvatar lazy circle :size="200" :src=urlAvatar style="cursor: pointer;" />
        </NUpload>
        <NAvatar v-else lazy circle :size="200" :src=urlAvatar />
      </NFlex>
      <NFlex vertical>
        <UserNameInfo :lastName=user.lastName :firstName=user.firstName :middleName=user.middleName :academicDegree=user.academicDegree :academicTitle=user.academicTitle />
        <NDivider :theme-overrides="dividerThemeOverrides"/>
        <UserDetailsInfo :posts=user.posts :email=user.email :phone=user.phone aud="" />
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
