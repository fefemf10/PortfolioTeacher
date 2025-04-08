<script setup lang="ts">
  const props = defineProps<{
    post: string,
    email: string,
    phone: string,
    aud: string,
  }>()
  import {NFlex, NIcon} from 'naive-ui'
  import { Briefcase, Envelope, Phone, Home } from '@vicons/fa'
  import UserDetailsInfoItem from './UserDetailsInfoItem.vue';
</script>
<template>
  <NFlex vertical>
      <UserDetailsInfoItem :icon=Briefcase :value=post />
      <UserDetailsInfoItem :icon=Envelope :value=email />
      <UserDetailsInfoItem :icon=Phone :value=phone />
      <UserDetailsInfoItem :icon=Home :value=aud />
  </NFlex>
</template>
