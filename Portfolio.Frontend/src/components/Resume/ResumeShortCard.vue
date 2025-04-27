<script setup lang="ts">
  import { ShortCardItem } from '@/classes/ShortCardItem';
  import { NTimeline, NTimelineItem, NText, NCard } from 'naive-ui';
  const props = defineProps<{
    title: string;
    items: ShortCardItem[];
  }>();
</script>
<template>
  <NCard style="border-radius: 0.5rem; box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);">
    <template #header>
      <NText type="info">{{title}}</NText>
    </template>
      <NTimeline size="large">
        <NTimelineItem v-for="carditem in items" type="info" :time=carditem.year :content=carditem.name />
      </NTimeline>
    </NCard>
</template>
