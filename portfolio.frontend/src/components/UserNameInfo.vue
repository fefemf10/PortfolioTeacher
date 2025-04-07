<script setup lang="ts">
  const props = defineProps<{
    lastName: string,
    firstName: string,
    middleName: string,
    academicDegree: string,
    academicTitle: string
  }>()
  import {NFlex, NText} from 'naive-ui'
</script>
<template>
  <NFlex vertical style="gap:unset">
    <NText class="fio" type="info">{{lastName }} {{firstName}} {{middleName}}</NText>
    <NText class="academic" type="info">{{ academicDegree }}, {{ academicTitle }}</NText>
  </NFlex>
</template>
<style scoped>
  .fio {
    font-size: x-large;
  }
  .academic {
    font-size: medium;
  }
</style>
