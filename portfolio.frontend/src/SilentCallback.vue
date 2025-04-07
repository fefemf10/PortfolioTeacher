<script setup lang="ts">
  import { onMounted } from 'vue';
  import { useRouter } from 'vue-router';
  import userManager from './oidc.js';
  const router = useRouter();

  onMounted(() => {
    userManager.signinSilentCallback();
  });
</script>

<template>
</template>
