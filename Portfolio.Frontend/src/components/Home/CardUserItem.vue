<script setup lang="ts">
  import { NText, NFlex, NAvatar } from 'naive-ui';
  import { Envelope, Phone } from '@vicons/fa';
  import UserDetailsInfoItem from '../UserDetailsInfoItem.vue';
  import { UserProfile } from '@/classes/UserProfile';
  import { PostType } from '@/enums/PostType';
  import { hashCode } from '@/hashCode';
  import { useEnumLocalization } from '@/EnumLocalization';
  import { useI18n } from 'vue-i18n';
  import { useDepartmentStore } from '@/stores/departmentStore';
  import { computed } from 'vue';
  const { t } = useI18n();
  const { localizeEnum } = useEnumLocalization();
  const props = defineProps<{
    user: UserProfile
  }>();
  const departmentStore = useDepartmentStore();
  const urlAvatar = computed(() => {
    if (props.user.avatar)
      return `/api/user/${props.user.id}/avatar`;
    else
      return `/images/id/AV${hashCode(props.user.id) % 100}.png`;
  });
</script>
<template>
  <NFlex>
        <NAvatar lazy circle :size="64" :src=urlAvatar />
        <NFlex class="fiopost" justify="space-between">
          <NFlex vertical>
            <NText class="fio" type="info">{{ user.lastName }} {{ user.firstName }} {{ user.middleName }}</NText>
            <NText class="post" type="info" v-for="post of user.posts">{{ localizeEnum(post.postType, PostType, 'Post') }} {{ t('Common.InDepartment') }} {{ departmentStore.getDepartmentById(post.departmentId)?.name }}</NText>
          </NFlex>
          <NFlex vertical>
            <UserDetailsInfoItem :icon=Envelope>{{ user.email }}</UserDetailsInfoItem>
            <UserDetailsInfoItem v-if="user.phone" :icon=Phone>{{ user.phone }}</UserDetailsInfoItem>
          </NFlex>
        </NFlex>
      </NFlex>
</template>
<style scoped>
  .fio {
    font-size: x-large;
  }
  .academic {
    font-size: medium;
  }
  .fiopost{
    width: calc(100% - 64px - 2rem);
  }
</style>
