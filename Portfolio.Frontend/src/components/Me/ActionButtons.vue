<script setup lang="ts" generic="T extends { id: string }">
import { NFlex, NButton, NIcon } from 'naive-ui'
import { PencilAlt as PencilIcon, Trash as TrashIcon } from '@vicons/fa'

const props = defineProps<{
  row: T
  onEdit: (row: T) => void
  onDelete: (id: string) => void
}>();
const handleEdit = (e, row) => {
  e.stopPropagation();
  props.onEdit(row);
};
const handleDelete = (e, id) => {
  e.stopPropagation();
  props.onDelete(id);
};
</script>

<template>
  <NFlex>
    <NButton size="small" type="primary" @click="(e) => handleEdit(e, row)">
      <NIcon :component="PencilIcon" />
    </NButton>
    <NButton size="small" type="error" @click="(e) => handleDelete(e, row.id)">
      <NIcon :component="TrashIcon" />
    </NButton>
  </NFlex>
</template>
