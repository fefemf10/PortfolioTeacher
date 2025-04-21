<script setup lang="ts">
  import { NFlex, NText } from 'naive-ui'
  import { AcademicDegree } from '../enums/AcademicDegree';
  import { AcademicTitle } from '../enums/AcademicTitle';
  import { useEnumLocalization } from '../EnumLocalization';
  const props = defineProps<{
    lastName: string,
    firstName: string,
    middleName: string,
    academicDegree: AcademicDegree,
    academicTitle: AcademicTitle
  }>();
  const { localizeEnum } = useEnumLocalization();
</script>
<template>
  <NFlex vertical style="gap:unset">
    <NText class="fio" type="info">{{lastName }} {{firstName}} {{middleName}}</NText>
    <NText class="academic" type="info">{{ localizeEnum(academicDegree, AcademicDegree, 'AcademicDegree') }}, {{ localizeEnum(academicTitle, AcademicTitle, 'AcademicTitle') }}</NText>
  </NFlex>
</template>
<style scoped>
  .fio {
    font-size: x-large;
  }
  .academic {
    font-size: medium;
  }
</style>
