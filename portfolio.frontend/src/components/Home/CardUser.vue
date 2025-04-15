<script setup lang="ts">
  import { NList, NListItem, NText, TextProps } from 'naive-ui';
  import { UserProfile } from '../../classes/UserProfile';
  import CardUserItem from './CardUserItem.vue';
  const props = defineProps<{
    user: UserProfile
  }>();
  type TextThemeOverrides = NonNullable<TextProps['themeOverrides']>
  const textThemeOverrides: TextThemeOverrides = {
    pFontSize: '20px',
  }
</script>
<template>
  <NList class="carduser">
    <template #header>
      <NText class="cardtitle" type="info">Список сотрудников</NText>
    </template>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
    <NListItem><CardUserItem :user=user /></NListItem>
  </NList>
</template>
<style scoped>
  .cardtitle {
    font-size: large;
    font-weight: bold;
  }
  .carduser{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
    padding: 1rem;
    min-width: 16rem;
  }

</style>
