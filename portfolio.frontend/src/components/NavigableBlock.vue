<script setup lang="ts">
import { Component, computed, h, onMounted, ref } from 'vue';
import {NTree, NCard, NText, TreeOption} from 'naive-ui'
import api from '../api';
interface Department {
  id: string
  name: string
}
interface Faculty {
  id: string
  name: string
  departments: Department[]
}
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
  const data = await api.get('api/faculty/departments').json<Faculty[]>();
  faculties.value = data;
});
</script>
<template>
  <NCard class="cards">
    <template #header>
      <NText class="cardtitle">Организационная структура</NText>
    </template>
    <NTree :data=treeData block-line expand-on-click>
    </NTree>
  </NCard>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
    width: 20vw;
  }
  .cardtitle {
    color: var(--n-color-target);
    font-size: large;
    font-weight: bold;
  }
</style>
