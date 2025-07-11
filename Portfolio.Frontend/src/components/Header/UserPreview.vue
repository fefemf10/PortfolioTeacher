<script setup lang="ts">
  import {NFlex, NAvatar, NText} from 'naive-ui'
  import { useUserStore } from '@/stores/userStore';
  import { hashCode } from '@/hashCode';
  import { computed } from 'vue';
  const userStore = useUserStore();
</script>
<template>
  <NFlex align="center" style="height: 3rem;" class="userpreview">
    <NAvatar lazy circle :size="32" :src="userStore.urlAvatar" />
    <NText type="info">{{ userStore.user?.lastName }} {{userStore.user?.firstName[0] }}.{{ userStore.user?.middleName[0] }}.</NText>
  </NFlex>
</template>
<style scoped>
  .userpreview:hover{
    cursor: pointer;
  }
</style>
