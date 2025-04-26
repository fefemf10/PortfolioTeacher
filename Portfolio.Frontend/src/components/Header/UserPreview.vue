<script setup lang="ts">
  import {NFlex, NAvatar, NText} from 'naive-ui'
  import {onMounted, ref} from 'vue';
  import { UserProfile } from '../../classes/UserProfile';
  import api from '../../api'
  import userManager, { guid } from '../../oidc'
  const user = ref<UserProfile>(null);
  onMounted(async () => {
    user.value = await api.get<UserProfile>('api/teacher/' + await guid()).json();
  });
</script>
<template>
  <NFlex align="center" style="height: 3rem;" class="userpreview">
    <NAvatar lazy circle :size="32" src="https://avatar.iran.liara.run/public" />
    <NText type="info">{{ user?.lastName }} {{ user?.firstName[0] }}.{{ user?.middleName[0] }}.</NText>
  </NFlex>
</template>
<style scoped>
  .userpreview:hover{
    cursor: pointer;
  }
</style>
