<script setup lang="ts">
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import userManager from '@/oidc';
const router = useRouter();
onMounted(() => {
  userManager.signinRedirectCallback().then(async () => {
      router.replace({ path: '/' });
  });
});
</script>

<template>
  <div>
    <p>Completing login...</p>
  </div>
</template>
