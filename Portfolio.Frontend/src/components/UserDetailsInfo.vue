<script setup lang="ts">
  import {NFlex, NIcon} from 'naive-ui'
  import { Briefcase, Envelope, Phone, Home } from '@vicons/fa'
  import UserDetailsInfoItem from './UserDetailsInfoItem.vue';
  import { Post } from '@/enums/PostEnum';
  import { useEnumLocalization } from '@/EnumLocalization';
  const props = defineProps<{
    email: string,
    post: Post,
    aud: string,
    phone: string
  }>();
  const { localizeEnum } = useEnumLocalization();
</script>
<template>
  <NFlex vertical>
      <UserDetailsInfoItem :icon=Briefcase :value="localizeEnum(post, Post, 'Post')" />
      <UserDetailsInfoItem :icon=Envelope :value=email />
      <UserDetailsInfoItem :icon=Phone :value=phone />
      <UserDetailsInfoItem :icon=Home :value=aud />
  </NFlex>
</template>
