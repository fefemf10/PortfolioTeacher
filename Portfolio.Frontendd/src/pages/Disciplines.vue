<script setup lang="ts">
  import { NCard, NText, NDataTable, DataTableColumns } from 'naive-ui'
  import {Discipline} from '../classes/Discipline'
  const data: Discipline[] = [
    { id: '15641651-4156', name: 'Кризис-менеджмент', form: 'Лекции', targetAudience: 'Бакалавриат'}
  ]
  const columns = [
      {
        title: 'Name',
        key: 'name'
      },
      {
        title: 'Form',
        key: 'form'
      },
      {
        title: 'Target Audience',
        key: 'targetAudience'
      }
    ]
</script>
<template>
  <NCard class="cards">
    <template #header>
      <NText class="cardtitle" type="success">Преподаваемые дисциплины</NText>
    </template>
    <NDataTable size="small" :columns="columns" :data="data" :pagination="false" bordered />
  </NCard>
</template>
<style>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
  }
  .cardtitle {
    font-size: large;
    font-weight: bold;
  }
</style>
