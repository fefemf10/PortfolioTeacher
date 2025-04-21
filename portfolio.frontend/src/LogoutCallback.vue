<script setup>
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import userManager, { userCreated } from './oidc.js';

const router = useRouter();

onMounted(() => {
  userManager.signoutRedirectCallback().then(() => {
    window.localStorage.setItem('user_api_created', 'false');
    userCreated.value = false;
    router.replace({ path: '/' });
  });
});
</script>

<template>
  <div>
    <p>Completing logout...</p>
  </div>
</template>
