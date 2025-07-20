<script setup lang="ts">
  import api from '@/api';
  import { onMounted } from 'vue';
  import { useRoute } from 'vue-router';
  const route = useRoute();
  onMounted(async () => {
    const response = await api.post(`Account/Logout?logoutId=${route.query.logoutId}`);
    if (response.ok)
      window.location.href = response.url;
  })
</script>
<template>
</template>
