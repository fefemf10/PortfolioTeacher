<script setup lang="ts">
  import { NLayout, NLayoutContent, NLayoutHeader, NLayoutFooter, NText, NButton } from 'naive-ui'
  import { RouterView } from 'vue-router'
  import { ref, onMounted, onBeforeUnmount } from 'vue'
  import userManager, { isAuthenticated, login, logout, userCreated } from './oidc';
  import UserPreview from './components/Header/UserPreview.vue';
  import ThemeSwitcher from './components/Footer/ThemeSwitcher.vue';
  import LanguageSwitcher from './components/Footer/LanguageSwitcher.vue';
  import { useI18n } from 'vue-i18n';
  import router from './Router';
  const { t } = useI18n();
  const auth = ref<boolean>(false);
  const updateAuthState = async () => {
    auth.value = await isAuthenticated();
    if (auth.value && !userCreated.value)
      router.replace('/registration');
  };
  onMounted(async () => {
    updateAuthState();
    userManager.events.addUserLoaded(updateAuthState);
    userManager.events.addUserUnloaded(() => {
      auth.value = false;
    });
  });
  onBeforeUnmount(() => {
    userManager.events.removeUserLoaded(updateAuthState);;
    userManager.events.removeUserUnloaded(() => {
      auth.value = false;
    });
  });
</script>
<template>
  <NLayout>
    <NLayoutHeader class="headfoot">
      <NText>ДонГТУ</NText>
      <UserPreview class="loginoutbtn" v-if="auth && userCreated"/>
      <NButton class="loginoutbtn" v-if="auth" :onClick="logout">{{ t('Nav.BtnLogout') }}</NButton>
      <NButton class="loginoutbtn" v-else="auth" :onClick="login">{{ t('Nav.BtnLogin') }}</NButton>
    </NLayoutHeader>
    <NLayoutContent content-style="min-height: calc(100dvh - 6rem); padding: 1rem; min-width: 320px;">
      <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
      <NText>&copy; Алдакимов Д. А., 2025</NText>
      <ThemeSwitcher />
      <LanguageSwitcher />
    </NLayoutFooter>
  </NLayout>
</template>
<style scoped>
  .routerview {
    padding: 0 1rem; min-width: calc(200px + 4rem);
  }
  .headfoot{
    font-size: large;
    font-weight: bold;
    display:flex;
    text-wrap-mode: nowrap;
    justify-content:center;
    align-items: center;
    height: 3rem;
    padding: 0 1rem;
  }
  .loginoutbtn{
    margin-left: 1rem;
  }
</style>
