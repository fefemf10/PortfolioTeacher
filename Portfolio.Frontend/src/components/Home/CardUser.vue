<script setup lang="ts">
  import { NList, NListItem, NText, TextProps } from 'naive-ui';
  import { UserProfile } from '@/classes/UserProfile';
  import CardUserItem from './CardUserItem.vue';
  import router from '@/Router';
  import { useI18n } from 'vue-i18n';
  const {t} = useI18n();
  const props = defineProps<{
    users: UserProfile[]
  }>();
  const click = (id:string) => {
    router.push(`/resume/${id}`);
  };
</script>
<template>
  <NList class="carduser" hoverable clickable>
    <template #header>
      <NText class="cardtitle" type="info">{{ t('Common.ListWorkers') }}</NText>
    </template>
    <NListItem v-for="user in users" @click="click(user.id)"><CardUserItem :user=user /></NListItem>
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
