<script setup lang="ts">
  import { MenuOption, NButton, NLayout, NLayoutContent, NLayoutSider, NMenu, NIcon } from 'naive-ui'
  import {
    User as UserIcon,
    Home as HomeIcon,
    Award as AwardIcon,
    Star as StarIcon,
    Book as BookIcon,
    Building as BuildingIcon,
    University as UniversityIcon,
    Flask as FlaskIcon,
    Walking as WalkingIcon,
    ListUl as ListUlIcon
  } from '@vicons/fa'
  import { useI18n } from 'vue-i18n'
  import { Component, h, ref, watch } from 'vue';
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
  function renderIcon(icon: Component) {
    return () => h(NIcon, { component: icon })
  }
  let getMenuOptions = (): MenuOption[] => [
    {label: () => h(RouterLink, { to: '/' }, { default: () => t('Pages.Home.NameTitle') }), key: '/', icon: renderIcon(HomeIcon)},
    {label: () => h(RouterLink, { to: '/about' }, { default: () => t('Pages.About.NameTitle') }), key: '/about', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/awards' }, { default: () => t('Pages.Awards.NameTitle') }), key: '/awards', icon: renderIcon(AwardIcon)},
    {label: () => h(RouterLink, { to: '/disciplines' }, { default: () => t('Pages.Disciplines.NameTitle') }), key: '/disciplines', icon: renderIcon(ListUlIcon)},
    {label: () => h(RouterLink, { to: '/dissertation' }, { default: () => t('Pages.Dissertation.NameTitle') }), key: '/dissertation', icon: renderIcon(BookIcon)},
    {label: () => h(RouterLink, { to: '/professionalDevelopments' }, { default: () => t('Pages.ProfessionalDevelopment.NameTitle') }), key: '/professionalDevelopments', icon: renderIcon(AwardIcon)},
    {label: () => h(RouterLink, { to: '/publicActivities' }, { default: () => t('Pages.PublicActivities.NameTitle') }), key: '/publicActivities', icon: renderIcon(WalkingIcon)},
    {label: () => h(RouterLink, { to: '/scienceProjects' }, { default: () => t('Pages.ScienceProjects.NameTitle') }), key: '/scienceProjects', icon: renderIcon(FlaskIcon)},
    {label: () => h(RouterLink, { to: '/university' }, { default: () => t('Pages.University.NameTitle') }), key: '/university', icon: renderIcon(UniversityIcon)},
    {label: () => h(RouterLink, { to: '/work' }, { default: () => t('Pages.Work.NameTitle') }), key: '/work', icon: renderIcon(BuildingIcon)},
    {label: () => h(RouterLink, { to: '/stats' }, { default: () => t('Pages.Stats.NameTitle') } ), key: '/stats', icon: renderIcon(StarIcon)},
    {label: () => h(RouterLink, { to: '/admin' }, { default: () => t('Pages.Admin.NameTitle') }), key: '/admin', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/dean' }, { default: () => t('Pages.Dean.NameTitle') }), key: '/dean', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/deputy' }, { default: () => t('Pages.Deputy.NameTitle') }), key: '/deputy', icon: renderIcon(UserIcon)},
    {label: () => h(NButton, { onClick: logout }, { default: () => t('Nav.BtnLogout') }), key: 'go-back-logout'},
  ];
  const menuOptions = getMenuOptions();
  const collapsed = ref(false);
</script>
<template>
  <NLayout has-sider>
    <NLayoutSider bordered show-trigger :collapsed="collapsed" collapse-mode="width" :collapsed-width="64" @collapse="collapsed = true" @expand="collapsed = false">
      <NMenu :options="menuOptions" :value="activeKey" :collapsed="collapsed" :collapsed-width="64" :collapsed-icon-size="32"/>
      <LanguageSwitcher/>
    </NLayoutSider>
    <NLayoutContent>
      <RouterView/>
    </NLayoutContent>
  </NLayout>
</template>
