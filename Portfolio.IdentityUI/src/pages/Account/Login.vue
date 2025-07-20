<script setup lang="ts">
import LoginForm from '@/components/LoginForm.vue';
import RegisterForm from '@/components/RegisterForm.vue';
import router from '@/Router';
import { NFlex, NText, NCard, NTabs, NTabPane, NButton, NIcon } from 'naive-ui'
import { useI18n } from 'vue-i18n';
const { t } = useI18n();
async function cancel(e: MouseEvent) {
  e.preventDefault();
  router.back();
};
</script>
<template>
  <NFlex vertical style="height: calc(100dvh - 5rem);" justify="center" align="center">
    <NCard style="max-width: 35em;
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);" size="small">
    <template #header>
      <NFlex :wrap="false">
        <NButton @click="cancel" type="warning" text style="font-size: 2.5rem"><NIcon><svg viewBox="0 0 512 512"><path d="M48 256c0 114.87 93.13 208 208 208s208-93.13 208-208S370.87 48 256 48S48 141.13 48 256zm212.65-91.36a16 16 0 0 1 .09 22.63L208.42 240H342a16 16 0 0 1 0 32H208.42l52.32 52.73A16 16 0 1 1 238 347.27l-79.39-80a16 16 0 0 1 0-22.54l79.39-80a16 16 0 0 1 22.65-.09z" fill="currentColor"></path></svg></NIcon></NButton>
        <NText style="margin-left: -2.5rem; width: 100%; text-align: center;" class="regtext" strong type="success">ДонГТУ ID</NText>
      </NFlex>
    </template>
      <NTabs type="segment" default-value="signin" size="large" animated justify-content="space-evenly">
      <NTabPane name="signin" :tab="t('Common.SignIn')">
        <LoginForm />
      </NTabPane>
      <NTabPane name="signup" :tab="t('Common.SignUp')">
        <RegisterForm />
      </NTabPane>
      </NTabs>
    </NCard>
  </NFlex>
</template>
<style scoped>
.regtext {
  font-size: 2.5em;
}
</style>
