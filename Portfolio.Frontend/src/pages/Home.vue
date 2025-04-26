<script setup lang="ts">
  import {NFlex, NButton} from 'naive-ui'
  import {onMounted, ref, watchEffect} from 'vue'
  import NavigableBlock from '../components/NavigableBlock.vue'
  import CardUser from '../components/Home/CardUser.vue';
  import { UserProfile } from '../classes/UserProfile';
  import api from '../api'
  const users = ref<UserProfile[]>([]);
  onMounted(async () => {
    users.value = await api.get<UserProfile[]>('api/teacher').json();
  });
  async function handleSelectedKey(id: string) {
    if (id?.startsWith('department'))
      users.value = await api.get<UserProfile[]>(`api/department/${id.split(' ')[1]}/teachers`).json();
    else if (id?.startsWith('faculty'))
      users.value = await api.get<UserProfile[]>(`api/faculty/${id.split(' ')[1]}/teachers`).json();
    else
      users.value = await api.get<UserProfile[]>('api/teacher').json();
  }
</script>
<template>
  <NFlex class="roothome" justify="space-between" size="large">
      <CardUser class="users" :users=users />
      <NavigableBlock class="navblock" @selected="handleSelectedKey" />
  </NFlex>
</template>
<style scoped>
  .users {
    width: calc(100% - 23rem);
    flex-shrink: 0;
    flex-grow: 1;
  }
  .navblock {
    width: 20rem;
    flex-grow: 1;
  }
</style>
