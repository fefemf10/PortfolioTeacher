<script setup lang="ts">
  import { NList, NListItem, NText, NFlex, NAvatar, TextProps } from 'naive-ui';
  import { Briefcase, Envelope, Phone, Home } from '@vicons/fa';
  import UserDetailsInfoItem from '../UserDetailsInfoItem.vue';
  import { UserProfile } from '../../classes/UserProfile';
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
    <NListItem>
      <NFlex>
        <NAvatar lazy circle :size="64" src="https://avatar.iran.liara.run/public" />
        <NFlex class="fiopost" justify="space-between">
          <NFlex vertical>
            <NText class="fio" type="info">{{ user.lastName }} {{ user.firstName }} {{ user.middleName }}</NText>
            <NText class="post" type="info">{{ user.post }}</NText>
          </NFlex>
          <NFlex vertical>
            <UserDetailsInfoItem :icon=Envelope :value=user.email />
            <UserDetailsInfoItem :icon=Phone :value=user.phone />
          </NFlex>
        </NFlex>
      </NFlex>
    </NListItem>
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
    min-width: 14rem;
  }
  .fio {
    font-size: x-large;
  }
  .academic {
    font-size: medium;
  }
  .fiopost{
    width: calc(100% - 64px - 2rem);
  }
</style>
