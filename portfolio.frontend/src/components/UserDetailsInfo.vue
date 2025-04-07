<script setup lang="ts">
  const props = defineProps<{
    post: string,
    email: string,
    phone: string,
    aud: string,
  }>()
  import {NFlex, NIcon} from 'naive-ui'
  import { Briefcase, Mail, PhonePortraitOutline, Home } from '@vicons/ionicons5'
  import UserDetailsInfoItem from './UserDetailsInfoItem.vue';
</script>
<template>
  <NFlex vertical>
      <UserDetailsInfoItem :icon=Briefcase :value=post />
      <UserDetailsInfoItem :icon=Mail :value=email />
      <UserDetailsInfoItem :icon=PhonePortraitOutline :value=phone />
      <UserDetailsInfoItem :icon=Home :value=aud />
  </NFlex>
</template>
