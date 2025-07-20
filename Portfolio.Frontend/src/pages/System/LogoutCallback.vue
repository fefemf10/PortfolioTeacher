<script setup>
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import userManager, { userCreated } from '@/oidc';

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
