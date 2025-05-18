<script setup lang="ts">
import { NFlex } from 'naive-ui';
import { UserProfile } from '@/classes/UserProfile';
import NavMenu from '@/components/NavMenu.vue';
import UserInfo from '@/components/UserInfo.vue';
import { useRoute } from 'vue-router'
import { onMounted, ref } from 'vue'
import api from '@/api';
import { guid } from '@/oidc';
const user = ref<UserProfile>(null);

onMounted(async () => {
  user.value = await api.get<UserProfile>(`api/teacher/${await guid()}`).json();
});
</script>
<template>
  <NFlex justify="center" vertical style="gap: 1rem;">
    <UserInfo v-if="user" :user=user :upload=true></UserInfo>
    <NavMenu route="/me" />
    <RouterView></RouterView>
  </NFlex>
</template>
