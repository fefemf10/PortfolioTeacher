<script setup lang="ts">
  import { PropType, Component } from 'vue';
  import {NFlex, NIcon, NText} from 'naive-ui'
  const props = defineProps<{
    icon: PropType<Component>,
    value: string,
  }>()
</script>
<template>
  <NFlex align="center" style="gap:unset" :wrap=false>
    <NIcon size="24" :component="icon"/>
    <NText class="text">{{ value }}</NText>
  </NFlex>
</template>
<style scoped>
  .text{
    margin-left: 0.5em;
  }
</style>
