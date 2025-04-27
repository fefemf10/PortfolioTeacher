<script setup lang="ts">
  import { NText, NFlex, NAvatar } from 'naive-ui';
  import { Envelope, Phone } from '@vicons/fa';
  import UserDetailsInfoItem from '../UserDetailsInfoItem.vue';
  import { UserProfile } from '@/classes/UserProfile';
  import { Post } from '@/enums/PostEnum';
  import { hashCode } from '@/hashCode';
  import { useEnumLocalization } from '@/EnumLocalization';
  const { localizeEnum } = useEnumLocalization();
  const props = defineProps<{
    user: UserProfile
  }>();

</script>
<template>
  <NFlex>
        <NAvatar lazy circle :size="64" :src='`https://avatar.iran.liara.run/public/${hashCode(user.id) % 100}`' />
        <NFlex class="fiopost" justify="space-between">
          <NFlex vertical>
            <NText class="fio" type="info">{{ user.lastName }} {{ user.firstName }} {{ user.middleName }}</NText>
            <NText class="post" type="info">{{ localizeEnum(user.post, Post, 'Post') }}</NText>
          </NFlex>
          <NFlex vertical>
            <UserDetailsInfoItem :icon=Envelope :value=user.email />
            <UserDetailsInfoItem v-if="user.phone" :icon=Phone :value=user.phone />
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
