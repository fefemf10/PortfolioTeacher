<script setup lang="ts">
  import { NLayout, NLayoutContent, NLayoutHeader, NLayoutFooter, NText, NButton, NFlex, NDropdown, NIcon } from 'naive-ui'
  import { RouterView } from 'vue-router'
  import { ref, onMounted, onBeforeUnmount, Component, h } from 'vue'
  import userManager, { isAuthenticated, login, logout, role, userCreated } from './oidc';
  import UserPreview from './components/Header/UserPreview.vue';
  import ThemeSwitcher from './components/Footer/ThemeSwitcher.vue';
  import LanguageSwitcher from './components/Footer/LanguageSwitcher.vue';
  import { useI18n } from 'vue-i18n';
  import router from './Router';
  import {
    SignOutAlt as LogoutIcon,
    User as UserIcon
  } from '@vicons/fa'
  import { useDepartmentStore } from './stores/departmentStore';
  const { t, locale } = useI18n();
  const auth = ref<boolean>(false);
  const departmentStore = useDepartmentStore();
  const updateAuthState = async () => {
    auth.value = await isAuthenticated();
    if (auth.value && !userCreated.value && await role() !== 'Administrator')
      router.replace('/registration');
  };
  onMounted(async () => {
    document.documentElement.lang = locale.value;
    updateAuthState();
    userManager.events.addUserLoaded(updateAuthState);
    userManager.events.addUserUnloaded(() => {
      auth.value = false;
    });
    departmentStore.fetchDepartments();
  });
  onBeforeUnmount(() => {
    userManager.events.removeUserLoaded(updateAuthState);;
    userManager.events.removeUserUnloaded(() => {
      auth.value = false;
    });
  });
  function renderIcon(icon: Component) {
    return () => h(NIcon, { component: icon })
  }
  const options = [
    {
      label: t('Nav.BtnLogout'),
      key: 'logout',
      icon: renderIcon(LogoutIcon)
    }
  ];
  function handleSelect(key: string | number) {
    if (key === 'logout')
      logout();
  }
</script>
<template>
  <NLayout>
    <NLayoutHeader class="headfoot">
      <RouterLink to='/'><NButton>ДонГТУ</NButton></RouterLink>
      <NFlex>
        <NDropdown trigger="click" :options="options" @select="handleSelect">
          <div>
          <UserPreview class="loginoutbtn" v-if="auth && userCreated && role().then(role => { return role !== 'Administrator'})" />
          </div>
        </NDropdown>
        <NButton class="loginoutbtn" v-if="!auth" :onClick="login">{{ t('Nav.BtnLogin') }}</NButton>
      </NFlex>
    </NLayoutHeader>
    <NLayoutContent content-style="min-height: calc(100dvh - 6rem); padding: 1rem; min-width: 320px;">
      <RouterView />
    </NLayoutContent>
    <NLayoutFooter class="headfoot">
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
    justify-content: space-between;
    align-items: center;
    height: 3rem;
    padding: 0 1rem;
  }
  .loginoutbtn{
    margin-left: 1rem;
  }
</style>
