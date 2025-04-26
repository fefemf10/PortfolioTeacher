<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import {NTree, NCard, NText, TreeOption} from 'naive-ui'
import api from '../api';
import { Faculty } from '../classes/Faculty';
const faculties = ref<Faculty[]>([]);
const treeData = computed<TreeOption[]>(() =>
  faculties.value.map(faculty => ({
    label: faculty.name,
    key: faculty.id,
    children: faculty.departments.map(dep => ({
      label: dep.name,
      key: dep.id
    }))
  }))
);
onMounted(async () => {
  faculties.value = await api.get('api/faculty/departments').json<Faculty[]>();
});
</script>
<template>
  <NCard class="cards">
    <template #header>
      <NText class="cardtitle" type="success">Организационная структура</NText>
    </template>
    <NTree :data=treeData block-line expand-on-click :animated=false show-line>
    </NTree>
  </NCard>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
    min-width: 16rem;
    height: fit-content;
  }
  .cardtitle {
    font-size: large;
    font-weight: bold;
  }
</style>
