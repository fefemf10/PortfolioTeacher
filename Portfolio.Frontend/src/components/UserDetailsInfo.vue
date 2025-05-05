<script setup lang="ts">
  import {NFlex, NIcon} from 'naive-ui'
  import { Briefcase, Envelope, Phone, Home } from '@vicons/fa'
  import UserDetailsInfoItem from './UserDetailsInfoItem.vue';
  import { useEnumLocalization } from '@/EnumLocalization';
  import { Post } from '@/classes/Post';
  import { PostType } from '@/enums/PostType';
import { useDepartmentStore } from '@/stores/departmentStore';
  const props = defineProps<{
    email: string,
    posts: Post[],
    aud: string,
    phone: string
  }>();
  const { localizeEnum } = useEnumLocalization();
  const departmentStore = useDepartmentStore();
</script>
<template>
  <NFlex vertical>
      <UserDetailsInfoItem v-for="post of posts" :icon=Briefcase :value="`${localizeEnum(post.postType, PostType, 'Post')} в подразделении ${departmentStore.getDepartmentById(post.departmentId)?.name}`" />
      <UserDetailsInfoItem :icon=Envelope :value=email />
      <UserDetailsInfoItem :icon=Phone :value=phone />
      <UserDetailsInfoItem :icon=Home :value=aud />
  </NFlex>
</template>
