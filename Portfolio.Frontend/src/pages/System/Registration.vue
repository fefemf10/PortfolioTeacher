<script setup lang="ts">
  import { NForm, NFormItemGi, NGrid, NInput, NButton, FormRules, NSelect, FormInst, SelectOption, NText } from 'naive-ui'
  import { computed, onMounted, ref } from 'vue'
  import { UserAddProfile } from '@/classes/UserAddProfile';
  import { useI18n } from 'vue-i18n';
  import { guid, userCreated } from '@/oidc';
  import api from '@/api'
  import router from '@/Router';
  import { useDepartmentStore } from '@/stores/departmentStore';
  const {t} = useI18n();
  const selectGenderOptions = computed<SelectOption[]>(() => [
    { label: t('Placeholders.Registration.genderMale'), value: 1 },
    { label: t('Placeholders.Registration.genderFemale'), value: 0 },
  ]);
  const departmentStore = useDepartmentStore();
  const selectOptions = computed<SelectOption[]>(() =>
    departmentStore.departments.map(faculty => ({
      type: 'group',
      label: faculty.shortName,
      key: faculty.id,
      children: faculty.childDepartments.map(department => ({
        label: department.name,
        value: department.id
      }))
   }))
  );
  const selectedDepartmentId = ref<string>(null)
  const formRef = ref<FormInst | null>(null);
  const formValue = ref<UserAddProfile>(new UserAddProfile());
  const rules: FormRules = {
    email: {
      required: true
    },
    lastName: {
      required: true
    },
    firstName: {
      required: true
    },
    gender: {
      required: true
    },
    phone: {
      required: true
    }
  };
  async function saveInfo(e: MouseEvent){
    e.preventDefault();
    formValue.value.id = await guid();
    formRef.value?.validate(async (errors) =>{
      if (!errors) {
        let response = await api.post('api/teacher', { json: formValue.value });
        if (response.ok){
          window.localStorage.setItem("user_api_created", "true");
          userCreated.value = true;
          router.replace({ path: '/' });
        }
      }
      else {
        console.error('invalid');
      }
    })
  };
</script>
<template>
  <NForm size="large" ref="formRef" :model="formValue" :rules="rules" style="max-width:60rem; margin: 0 auto;">
    <NText class="regtext" type="success">Введите пожалуйста свои данные</NText>
    <NGrid cols="1 640:3" item-responsive responsive="self" x-gap="24">
      <NFormItemGi path="lastName">
        <NInput v-model:value="formValue.lastName" :placeholder="t('Placeholders.Registration.lastName')"/>
      </NFormItemGi>
      <NFormItemGi path="firstName">
        <NInput v-model:value="formValue.firstName" :placeholder="t('Placeholders.Registration.firstName')"/>
      </NFormItemGi>
      <NFormItemGi path="middleName">
        <NInput v-model:value="formValue.middleName" :placeholder="t('Placeholders.Registration.middleName')"/>
      </NFormItemGi>
      <NFormItemGi path="gender">
        <NSelect v-model:value="formValue.gender" :options="selectGenderOptions" :placeholder="t('Placeholders.Registration.gender')" />
      </NFormItemGi>
      <NFormItemGi path="email">
        <NInput v-model:value="formValue.email" :placeholder="t('Placeholders.Registration.email')"/>
      </NFormItemGi>
      <NFormItemGi path="phone">
        <NInput v-model:value="formValue.phone" :placeholder="t('Placeholders.Registration.phone')"/>
      </NFormItemGi>
      <!-- <NFormItemGi path="departmentId">
        <NSelect v-model:value="formValue.departmentId" :options="selectOptions" :placeholder="t('Placeholders.Registration.department')" />
      </NFormItemGi> -->
      <NFormItemGi suffix>
        <NButton @click="saveInfo">{{ t('Placeholders.Registration.btnSave') }}</NButton>
      </NFormItemGi>
    </NGrid>
  </NForm>
</template>
<style scoped>
  .regtext {
    font-size: xx-large;
  }
</style>
