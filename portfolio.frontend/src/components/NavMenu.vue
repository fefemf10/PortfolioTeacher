<script setup lang="ts">
import { Component, h } from 'vue';
import {NFlex, NDropdown, NIcon, DropdownOption, NButton} from 'naive-ui'
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
import { RouterLink } from 'vue-router';
import { logout } from '../oidc';
const { t } = useI18n()
function renderIcon(icon: Component) {
    return () => h(NIcon, { component: icon })
  }
let getMenuOptions = (): DropdownOption[] => [
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
  ];
  const menuOptions = getMenuOptions();
</script>
<template>
  <NFlex justify="space-around" style="gap: 0.5rem">
    <NDropdown :options="menuOptions">
      <NButton>Образование</NButton>
    </NDropdown>
    <RouterLink to="/"><NButton :render-icon=renderIcon(HomeIcon)>{{ t('Pages.Home.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/about"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.About.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/awards"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.Awards.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/disciplines"><NButton :render-icon=renderIcon(ListUlIcon)>{{ t('Pages.Disciplines.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/dissertation"><NButton :render-icon=renderIcon(BookIcon)>{{ t('Pages.Dissertation.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/professionalDevelopments"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.ProfessionalDevelopment.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/publicActivities"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.PublicActivities.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/scienceProjects"><NButton :render-icon=renderIcon(FlaskIcon)>{{ t('Pages.ScienceProjects.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/university"><NButton :render-icon=renderIcon(UniversityIcon)>{{ t('Pages.University.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/work"><NButton :render-icon=renderIcon(BuildingIcon)>{{ t('Pages.Work.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/stats"><NButton :render-icon=renderIcon(StarIcon)>{{ t('Pages.Stats.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/admin"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Admin.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/dean"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Dean.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/deputy"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Deputy.NameTitle') }}</NButton></RouterLink>
    <RouterLink to="/"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Deputy.NameTitle') }}</NButton></RouterLink>
    <NButton :onclick=logout>{{ t('Nav.BtnLogout') }}</NButton>
  </NFlex>
</template>
