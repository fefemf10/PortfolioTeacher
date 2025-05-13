<script setup lang="ts">
  import { NFlex, NInput } from 'naive-ui'
  import { onMounted, ref } from 'vue'
  import { UserProfile } from '@/classes/UserProfile';
  import NavigableBlock from '@/components/NavigableBlock.vue'
  import CardUser from '@/components/Home/CardUser.vue';
  import api from '@/api'
  const searchQuery = ref('');
  const users = ref<UserProfile[]>([]);
  const filtredUsers = ref<UserProfile[]>([]);
  onMounted(async () => {
    users.value = await api.get<UserProfile[]>('api/teacher').json();
    filtredUsers.valye = users.value;
  });
  async function handleSelectedKey(id: string) {
    if (id === 'all')
      users.value = await api.get<UserProfile[]>('api/teacher').json();
    else
      users.value = await api.get<UserProfile[]>(`api/department/${id}/teachers`).json();
    filtredUsers.value = filterUsers(users.value, searchQuery.value);
  }
  const filterUsers = (userList: UserProfile[], query: string) => {
    if (!query) return userList;

    const lowerQuery = query.toLowerCase();
    return userList.filter(user => {
      const fullName = `${user.lastName} ${user.firstName} ${user.middleName || ''}`.toLowerCase();
      return fullName.includes(lowerQuery);
    });
  };

  const handleSearch = (value: string) => {
    searchQuery.value = value;
    filtredUsers.value = filterUsers(users.value, value);
  };
</script>
<template>
  <NFlex class="roothome" justify="space-between" size="large">
      <NFlex>
        <NInput placeholder="Поиск по ФИО" clearable @update:value="handleSearch" />
        <CardUser class="users" :users=filtredUsers />
      </NFlex>
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
