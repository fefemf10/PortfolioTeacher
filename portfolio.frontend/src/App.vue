<script setup lang="ts">
  import { MenuOption, NButton, NLayout, NLayoutContent, NLayoutSider, NMenu } from 'naive-ui'
  import { useI18n } from 'vue-i18n'
  import { h, ref, watch } from 'vue';
  import { RouterLink, useRoute } from 'vue-router'
  import LanguageSwitcher from './components/LanguageSwitcher.vue';
  import { logout } from './oidc';
  const route = useRoute()
  const { t } = useI18n()
  const activeKey = ref(route.path)
  watch(
    () => route.path,
    (newPath) => {
      activeKey.value = newPath
    }
  )
  let getMenuOptions = (): MenuOption[] => [
    {label: () => h(RouterLink, { to: '/' }, { default: () => t('Pages.Home.NameTitle') }), key: '/'},
    {label: () => h(RouterLink, { to: '/about' }, { default: () => t('Pages.About.NameTitle') }), key: '/about'},
    {label: () => h(RouterLink, { to: '/awards' }, { default: () => t('Pages.Awards.NameTitle') }), key: '/awards'},
    {label: () => h(RouterLink, { to: '/disciplines' }, { default: () => t('Pages.Disciplines.NameTitle') }), key: '/disciplines'},
    {label: () => h(RouterLink, { to: '/dissertation' }, { default: () => t('Pages.Dissertation.NameTitle') }), key: '/dissertation'},
    {label: () => h(RouterLink, { to: '/professionalDevelopments' }, { default: () => t('Pages.ProfessionalDevelopment.NameTitle') }), key: '/professionalDevelopments'},
    {label: () => h(RouterLink, { to: '/publicActivities' }, { default: () => t('Pages.PublicActivities.NameTitle') }), key: '/publicActivities'},
    {label: () => h(RouterLink, { to: '/scienceProjects' }, { default: () => t('Pages.ScienceProjects.NameTitle') }), key: '/scienceProjects'},
    {label: () => h(RouterLink, { to: '/university' }, { default: () => t('Pages.University.NameTitle') }), key: '/university'},
    {label: () => h(RouterLink, { to: '/work' }, { default: () => t('Pages.Work.NameTitle') }), key: '/work'},
    {label: () => h(RouterLink, { to: '/stats' }, { default: () => t('Pages.Stats.NameTitle') } ), key: '/stats'},
    {label: () => h(RouterLink, { to: '/admin' }, { default: () => t('Pages.Admin.NameTitle') }), key: '/admin'},
    {label: () => h(RouterLink, { to: '/dean' }, { default: () => t('Pages.Dean.NameTitle') }), key: '/dean'},
    {label: () => h(RouterLink, { to: '/deputy' }, { default: () => t('Pages.Deputy.NameTitle') }), key: '/deputy'},
    {label: () => h(NButton, { onClick: logout }, { default: () => t('Nav.BtnLogout') }), key: 'go-back-logout'},
  ];
  const menuOptions = getMenuOptions();
</script>
<template>
  <NLayout has-sider>
    <NLayoutSider>
      <NMenu :options="menuOptions" :value="activeKey" />
      <LanguageSwitcher/>
    </NLayoutSider>
    <NLayoutContent>
      <RouterView/>
    </NLayoutContent>
  </NLayout>
</template>
