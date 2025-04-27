<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { NTree, NCard, NText, TreeOption } from 'naive-ui'
import api from '@/api';
import { Faculty } from '@/classes/Faculty';
const faculties = ref<Faculty[]>([]);
const expandedKeys = ref<string[]>(['all']);
const selectedId = ref<string | null>(null);
const treeData = computed<TreeOption[]>(() => [{
  label: 'Все',
  key: 'all',
  children: faculties.value.map(faculty => ({
    label: faculty.name,
    key: `faculty ${faculty.id}`,
    children: faculty.departments.map(dep => ({
      label: dep.name,
      key: `department ${dep.id}`
    }))
  }))
}]);
onMounted(async () => {
  faculties.value = await api.get('api/faculty/departments').json<Faculty[]>();
});
const emit = defineEmits<{
  (e: 'selected', id: string | null): void
}>();
function handleSelectedKeys(keys){
  selectedId.value = keys[0];
  emit('selected', selectedId.value);
}
function handleExpandedKeys(keys: string[]) {
  expandedKeys.value = keys;
}
</script>
<template>
  <NCard class="cards">
    <template #header>
      <NText class="cardtitle" type="success">Организационная структура</NText>
    </template>
    <NTree :data=treeData block-line :animated=false show-line
    :selected-keys="[selectedId]"
    :expanded-keys="expandedKeys"
    @update:selected-keys="handleSelectedKeys"
    @update:expanded-keys="handleExpandedKeys" />
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
