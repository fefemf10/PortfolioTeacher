<script setup lang="ts">
  import {NFlex, NIcon} from 'naive-ui'
  import { Briefcase, Envelope, Phone, Home } from '@vicons/fa'
  import UserDetailsInfoItem from './UserDetailsInfoItem.vue';
  import { useEnumLocalization } from '@/EnumLocalization';
  import { useI18n } from 'vue-i18n';
  import { Post } from '@/classes/Post';
  import { PostType } from '@/enums/PostType';
  import { useDepartmentStore } from '@/stores/departmentStore';
  const props = defineProps<{
    email: string,
    posts: Post[],
    aud: string,
    phone: string
  }>();
  const { t } = useI18n();
  const { localizeEnum } = useEnumLocalization();
  const departmentStore = useDepartmentStore();
</script>
<template>
  <NFlex vertical>
      <UserDetailsInfoItem v-for="post of posts" :icon=Briefcase>{{localizeEnum(post.postType, PostType, 'Post')}} {{ t('Common.InDepartment') }} <RouterLink to='/'>{{departmentStore.getDepartmentById(post.departmentId)?.name}}</RouterLink></UserDetailsInfoItem>
      <UserDetailsInfoItem :icon=Envelope>{{ email }}</UserDetailsInfoItem>
      <UserDetailsInfoItem :icon=Phone>{{ phone }}</UserDetailsInfoItem>
      <UserDetailsInfoItem :icon=Home>{{ aud }}</UserDetailsInfoItem>
  </NFlex>
</template>
