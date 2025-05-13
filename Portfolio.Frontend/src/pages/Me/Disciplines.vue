<script setup lang="ts">
  import { NDataTable, NButton, NIcon, NForm, NSelect, NSpace, NModal } from 'naive-ui';
  import { Discipline } from '@/classes/Discipline';
  import { Component, computed, onMounted, ref } from 'vue';
  import api from '@/api';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { guid } from '@/oidc';
  import { h } from 'vue';
  import {
      Trash as TrashIcon,
      Plus as PlusIcon
    } from '@vicons/fa'
  const { t } = useI18n();
  const showAddModal = ref(false)
  const newDisciplineId = ref<string | null>(null)
  const loading = ref(false)
  const disciplineOptions = ref<{ label: string; value: string }[]>([])
  const data = ref<Discipline[]>([]);
  const allDisciplines = ref<Discipline[]>([]);
  function renderIcon(icon: Component) {
    return () => h(NIcon, { component: icon })
  }
  const columns = computed(() => [
    {
      title: t('Pages.Resume.Disciplines.DataColumns.0'),
      key: 'name'
    },
    {
      key: 'actions',
      width: 48,
      render: (row: Discipline) => h(NButton, {
        type: 'error',
        size: 'small',
        onClick: () => handleDelete(row.id)
      },
      { default: () => h(renderIcon(TrashIcon)) })
    }
  ]);

  const handleDelete = async (id: string) => {
    try {
      await api.delete(`api/teacher/${await guid()}/discipline/${id}`);
      data.value = data.value.filter(item => item.id !== id);
      const deletedDiscipline = allDisciplines.value.find(d => d.id === id)
      disciplineOptions.value = [...disciplineOptions.value, { label: deletedDiscipline.name, value: deletedDiscipline.id }];
    } catch (error) {
      console.error('Error deleting discipline:', error);
    }
  };

  const handleAdd = () => {
    newDisciplineId.value = null;
    showAddModal.value = true;
  };
  const submitAddDiscipline = async () => {
    if (!newDisciplineId.value) return

    loading.value = true
    try {
      await api.post(`api/teacher/${await guid()}/discipline/${newDisciplineId.value}`).json();

      const addedDiscipline = allDisciplines.value.find(d => d.id === newDisciplineId.value)
      if (addedDiscipline) {
        data.value = [...data.value, addedDiscipline];
        disciplineOptions.value = disciplineOptions.value.filter(o => o.value !== newDisciplineId.value);
      }
      showAddModal.value = false;
      newDisciplineId.value = null;
    } catch (error) {
      console.error('Error adding discipline:', error)
    } finally {
      loading.value = false
    }
  }
  onMounted(async () => {
    allDisciplines.value = await api.get<Discipline[]>(`api/discipline`).json();
    data.value = await api.get<Discipline[]>(`api/teacher/${await guid()}/discipline`).json();
    disciplineOptions.value = allDisciplines.value
      .filter(d => !data.value.some(userD => userD.id === d.id))
      .map(d => ({ label: d.name, value: d.id }))
  });
</script>

<template>
  <MyNCard :title="t('Pages.Resume.Disciplines.CardTitle')">
    <template #header-extra>
      <NButton type="primary" @click="handleAdd"><NIcon size="large" :component="PlusIcon" /></NButton>
    </template>
    <NDataTable :columns="columns" :data="data" bordered />
    <NModal v-model:show="showAddModal" preset="dialog" :title="t('Pages.Resume.Disciplines.DialogTitle')">
      <NForm>
          <NSelect v-model:value="newDisciplineId" :options="disciplineOptions" :placeholder="t('Pages.Resume.Disciplines.SelectPlaceholder')" filterable/>
      </NForm>

      <template #action>
        <NSpace justify="end">
          <NButton @click="showAddModal = false">{{ t('Common.Cancel') }}</NButton>
          <NButton type="primary" :loading="loading" :disabled="!newDisciplineId" @click="submitAddDiscipline">{{ t('Common.Add') }}</NButton>
        </NSpace>
      </template>
    </NModal>
  </MyNCard>
</template>
