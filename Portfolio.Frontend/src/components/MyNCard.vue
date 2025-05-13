<script setup lang="ts">
  import { NCard, NText } from 'naive-ui';
  import { ref } from 'vue';
  const props = defineProps<{
    title?: string | null
  }>();
</script>
<template>
  <NCard class="cards">
    <template #header-extra>
      <slot name="header-extra"></slot>
    </template>
    <template #header>
      <NText v-if=title class="cardtitle" type="success">{{ title }}</NText>
    </template>
    <slot></slot>
  </NCard>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
  }
  .cardtitle {
    font-size: large;
    font-weight: bold;
  }
</style>
