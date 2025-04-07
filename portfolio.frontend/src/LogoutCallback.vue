<script setup>
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import userManager from './oidc.js';

const router = useRouter();

onMounted(() => {
  userManager.signoutRedirectCallback().then(() => {
    router.replace({ path: '/' });
  });
});
</script>

<template>
  <div>
    <p>Completing logout...</p>
  </div>
</template>
