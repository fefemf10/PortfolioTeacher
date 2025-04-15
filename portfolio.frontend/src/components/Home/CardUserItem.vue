<script setup lang="ts">
  import { NText, NFlex, NAvatar } from 'naive-ui';
  import { Envelope, Phone } from '@vicons/fa';
  import UserDetailsInfoItem from '../UserDetailsInfoItem.vue';
  import { UserProfile } from '../../classes/UserProfile';
  const props = defineProps<{
    user: UserProfile
  }>();
</script>
<template>
  <NFlex>
        <NAvatar lazy circle :size="64" src="https://avatar.iran.liara.run/public" />
        <NFlex class="fiopost" justify="space-between">
          <NFlex vertical>
            <NText class="fio" type="info">{{ user.lastName }} {{ user.firstName }} {{ user.middleName }}</NText>
            <NText class="post" type="info">{{ user.post }}</NText>
          </NFlex>
          <NFlex vertical>
            <UserDetailsInfoItem :icon=Envelope :value=user.email />
            <UserDetailsInfoItem :icon=Phone :value=user.phone />
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
