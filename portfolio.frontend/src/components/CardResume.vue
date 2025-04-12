<script setup lang="ts">
  import { NTimeline, NTimelineItem, NText, NCard } from 'naive-ui';
</script>
<template>
  <NCard class="cards">
    <template #header>
      <NText class="cardtitle">Образование</NText>
    </template>
      <NTimeline size="large">
        <NTimelineItem type="info" time="2025 г." content="Oops" />
        <NTimelineItem type="info" time="2024 г." content="Oops" />
        <NTimelineItem type="info" time="2024 г." content="Oops" />
        <NTimelineItem type="info" time="2020 г." content="Oops" />
        <NTimelineItem type="info" time="2018 г." content="Oops" />
        <NTimelineItem type="info" time="2018 г." content="Oops" />
      </NTimeline>
    </NCard>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
  }
  .cardtitle {
    color: var(--n-color-target);
    font-size: large;
    font-weight: bold;
  }
</style>
