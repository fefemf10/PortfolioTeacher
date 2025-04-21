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
  <NFlex>
    <NAvatar lazy circle :size="32" src="https://avatar.iran.liara.run/public" />
    <NText class="fio" type="info">{{ user?.lastName }} {{ user?.firstName }} {{ user?.middleName }}</NText>
  </NFlex>
</template>
<style scoped>
</style>
