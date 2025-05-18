<script setup lang="ts">
  import {NFlex, NAvatar, NText} from 'naive-ui'
  import { onMounted, ref} from 'vue';
  import { UserProfile } from '@/classes/UserProfile';
  import api from '@/api'
  import { guid } from '@/oidc'
  import { hashCode } from '@/hashCode';
  const user = ref<UserProfile>(null);
  const urlAvatar = ref<string>(null);
  onMounted(async () => {
    user.value = await api.get<UserProfile>('api/teacher/' + await guid()).json();
    if (user.value.avatar)
      urlAvatar.value = `/api/user/${user.value.id}/avatar`;
    else
      urlAvatar.value = `https://avatar.iran.liara.run/public/${hashCode(user.value.id) % 100}`;
  });
</script>
<template>
  <NFlex align="center" style="height: 3rem;" class="userpreview">
    <NAvatar lazy circle :size="32" :src=urlAvatar />
    <NText type="info">{{ user?.lastName }} {{ user?.firstName[0] }}.{{ user?.middleName[0] }}.</NText>
  </NFlex>
</template>
<style scoped>
  .userpreview:hover{
    cursor: pointer;
  }
</style>
