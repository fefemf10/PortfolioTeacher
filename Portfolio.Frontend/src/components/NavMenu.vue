<script setup lang="ts">
  import { Component, h } from 'vue';
  import {NFlex, NDropdown, NIcon, DropdownOption, NButton} from 'naive-ui'
  import {
      Home as HomeIcon,
      Award as AwardIcon,
      Book as BookIcon,
      Building as BuildingIcon,
      University as UniversityIcon,
      Flask as FlaskIcon,
      Walking as WalkingIcon,
      ListUl as ListUlIcon
    } from '@vicons/fa'
  import { useI18n } from 'vue-i18n'
  import { RouterLink } from 'vue-router';
  const props = defineProps<{
    route: string
  }>();
  const { t } = useI18n()
  function renderIcon(icon: Component) {
      return () => h(NIcon, { component: icon })
    }
  let getMenuOptions = (): DropdownOption[] => [
    {label: () => h(RouterLink, { to: `${props.route}/monographies` }, { default: () => t('Pages.Resume.Monographies.NameTitle') }), key: '/monographies', icon: renderIcon(WalkingIcon)},
    {label: () => h(RouterLink, { to: `${props.route}/theses` }, { default: () => t('Pages.Resume.Theses.NameTitle') }), key: '/theses', icon: renderIcon(WalkingIcon)},
    {label: () => h(RouterLink, { to: `${props.route}/articles` }, { default: () => t('Pages.Resume.Articles.NameTitle') }), key: '/articles', icon: renderIcon(WalkingIcon)},
  ];
  const menuOptions = getMenuOptions();
</script>
<template>
  <NFlex justify="space-evenly" style="gap: 0.5rem">
    <RouterLink :to="`${route}`"><NButton :render-icon=renderIcon(HomeIcon)>{{ t('Pages.Home.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/awards`"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.Resume.Awards.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/disciplines`"><NButton :render-icon=renderIcon(ListUlIcon)>{{ t('Pages.Resume.Disciplines.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/dissertations`"><NButton :render-icon=renderIcon(BookIcon)>{{ t('Pages.Resume.Dissertations.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/professionalDevelopments`"><NButton :render-icon=renderIcon(AwardIcon)>{{ t('Pages.Resume.ProfessionalDevelopments.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/publicActivities`"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.Resume.PublicActivities.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/dissertations`"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.Resume.Dissertations.NameTitle') }}</NButton></RouterLink>
    <NDropdown :options="menuOptions"><NButton :render-icon=renderIcon(WalkingIcon)>{{ t('Pages.Resume.Publications.NameTitle') }}</NButton></NDropdown>
    <RouterLink :to="`${route}/scienceProjects`"><NButton :render-icon=renderIcon(FlaskIcon)>{{ t('Pages.Resume.ScienceProjects.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/universities`"><NButton :render-icon=renderIcon(UniversityIcon)>{{ t('Pages.Resume.University.NameTitle') }}</NButton></RouterLink>
    <RouterLink :to="`${route}/works`"><NButton :render-icon=renderIcon(BuildingIcon)>{{ t('Pages.Resume.Work.NameTitle') }}</NButton></RouterLink>
  </NFlex>
</template>
