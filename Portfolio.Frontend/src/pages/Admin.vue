<script setup lang="ts">
  import api from '@/api';
  import id from '@/id';
  import { NButton } from 'naive-ui';
  import { ref } from 'vue';
  const data = ref(null);
  async function click() {
    data.value = await id.post('api/user').json();
    const response = await api.post('api/admin/test-users', { json: data.value });
    if (!response.ok)
      await id.delete('api/user', { json: data.value });
  }
  async function del() {
    await id.delete('api/user', { json: data.value });
  }
</script>
<template>
  <NButton @click="click">Создать тестовых пользователей</NButton>
  <NButton @click="del">Удалить тестовых пользователей</NButton>
</template>
