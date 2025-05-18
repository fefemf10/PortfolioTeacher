<script setup lang="ts" generic="T extends { id: string }">
import { NFlex, NButton, NIcon } from 'naive-ui'
import { PencilAlt as PencilIcon, Trash as TrashIcon } from '@vicons/fa'

const props = defineProps<{
  row: T
  onEdit: (row: T) => void
  onDelete: (id: string) => void
}>()
</script>

<template>
  <NFlex>
    <NButton size="small" type="primary" @click="onEdit(row)">
      <NIcon :component="PencilIcon" />
    </NButton>
    <NButton size="small" type="error" @click="onDelete(row.id)">
      <NIcon :component="TrashIcon" />
    </NButton>
  </NFlex>
</template>
