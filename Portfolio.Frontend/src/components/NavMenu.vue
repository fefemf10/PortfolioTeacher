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
import { logout } from '@/oidc';
import {useRoute} from 'vue-router'
const route = useRoute();
const { t } = useI18n()
function renderIcon(icon: Component) {
    return () => h(NIcon, { component: icon })
  }
let getMenuOptions = (): DropdownOption[] => [
    {label: () => h(RouterLink, { to: '/' }, { default: () => t('Pages.Home.NameTitle') }), key: '/', icon: renderIcon(HomeIcon)},
    {label: () => h(RouterLink, { to: '/about' }, { default: () => t('Pages.About.NameTitle') }), key: '/about', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/awards' }, { default: () => t('Pages.Resume.Awards.NameTitle') }), key: '/awards', icon: renderIcon(AwardIcon)},
    {label: () => h(RouterLink, { to: '/disciplines' }, { default: () => t('Pages.Resume.Disciplines.NameTitle') }), key: '/disciplines', icon: renderIcon(ListUlIcon)},
    {label: () => h(RouterLink, { to: '/dissertation' }, { default: () => t('Pages.Resume.Dissertations.NameTitle') }), key: '/dissertation', icon: renderIcon(BookIcon)},
    {label: () => h(RouterLink, { to: '/professionalDevelopments' }, { default: () => t('Pages.Resume.ProfessionalDevelopments.NameTitle') }), key: '/professionalDevelopments', icon: renderIcon(AwardIcon)},
    {label: () => h(RouterLink, { to: '/publicActivities' }, { default: () => t('Pages.Resume.PublicActivities.NameTitle') }), key: '/publicActivities', icon: renderIcon(WalkingIcon)},
    {label: () => h(RouterLink, { to: '/publications' }, { default: () => t('Pages.Resume.Publications.NameTitle') }), key: '/publications', icon: renderIcon(WalkingIcon)},
    {label: () => h(RouterLink, { to: '/scienceProjects' }, { default: () => t('Pages.Resume.ScienceProjects.NameTitle') }), key: '/scienceProjects', icon: renderIcon(FlaskIcon)},
    {label: () => h(RouterLink, { to: '/university' }, { default: () => t('Pages.Resume.University.NameTitle') }), key: '/university', icon: renderIcon(UniversityIcon)},
    {label: () => h(RouterLink, { to: '/work' }, { default: () => t('Pages.Resume.Work.NameTitle') }), key: '/work', icon: renderIcon(BuildingIcon)},
    {label: () => h(RouterLink, { to: '/stats' }, { default: () => t('Pages.Stats.NameTitle') } ), key: '/stats', icon: renderIcon(StarIcon)},
    {label: () => h(RouterLink, { to: '/admin' }, { default: () => t('Pages.Admin.NameTitle') }), key: '/admin', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/dean' }, { default: () => t('Pages.Dean.NameTitle') }), key: '/dean', icon: renderIcon(UserIcon)},
    {label: () => h(RouterLink, { to: '/deputy' }, { default: () => t('Pages.Deputy.NameTitle') }), key: '/deputy', icon: renderIcon(UserIcon)},
  ];
  const menuOptions = getMenuOptions();
</script>
<template>
  <NFlex justify="space-beetween" style="gap: 0.5rem">
    <!-- <NDropdown :options="menuOptions">
      <NButton>Образование</NButton>
    </NDropdown> -->
    <!-- <RouterLink :to="`/about`"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.About.NameTitle') }}</NButton></RouterLink> -->
    <RouterLink :to="`/resume/${route.params.id}`"><NButton :render-icon=renderIcon(HomeIcon)>{{ t('Pages.Home.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/awards`"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.Resume.Awards.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/disciplines`"><NButton :render-icon=renderIcon(ListUlIcon)>{{ t('Pages.Resume.Disciplines.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/dissertations`"><NButton :render-icon=renderIcon(BookIcon)>{{ t('Pages.Resume.Dissertations.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/professionalDevelopments`"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.Resume.ProfessionalDevelopments.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/publicActivities`"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.Resume.PublicActivities.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/publications`"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.Resume.Publications.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/scienceProjects`"><NButton :render-icon=renderIcon(FlaskIcon)>{{ t('Pages.Resume.ScienceProjects.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/universities`"><NButton :render-icon=renderIcon(UniversityIcon)>{{ t('Pages.Resume.University.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`/resume/${route.params.id}/works`"><NButton :render-icon=renderIcon(BuildingIcon)>{{ t('Pages.Resume.Work.NameTitle') }}</NButton></RouterLink>

    <!-- <RouterLink :to="`/stats`"><NButton :render-icon=renderIcon(StarIcon)>{{ t('Pages.Stats.NameTitle') }}</NButton></RouterLink> -->
    <!-- <RouterLink :to="`/admin`"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Admin.NameTitle') }}</NButton></RouterLink> -->
    <!-- <RouterLink :to="`/dean`"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Dean.NameTitle') }}</NButton></RouterLink> -->
    <!-- <RouterLink :to="`/deputy`"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Deputy.NameTitle') }}</NButton></RouterLink> -->
    <!-- <RouterLink :to="`/`"><NButton :render-icon=renderIcon(UserIcon)>{{ t('Pages.Deputy.NameTitle') }}</NButton></RouterLink> -->
    <!-- <NButton :onclick=logout>{{ t('Nav.BtnLogout') }}</NButton> -->
  </NFlex>
</template>
