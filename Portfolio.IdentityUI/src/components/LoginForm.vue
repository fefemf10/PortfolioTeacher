<script setup lang="ts">
import api from '@/api';
import { FormInst, FormRules, NForm, NFormItemGi, NGrid, NInput, NButton, NCheckbox, FormItemRule, useMessage } from 'naive-ui';
import { ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { useRoute } from 'vue-router';
const route = useRoute();
const { t } = useI18n();
const message = useMessage()
interface LoginModel {
  email: string | null;
  password: string | null;
  rememberLogin: boolean;
  returnUrl: string | null;
  button: string | null;
}
const loading = ref(false)
const formRef = ref<FormInst | null>(null);
const modelRef = ref<LoginModel>({
  email: null,
  password: null,
  rememberLogin: false,
  returnUrl: route.query.ReturnUrl as string,
  button: null
});
function validateEmail(rule: FormItemRule, value: string): boolean {
  return /^\S+@\S+\.\S+$/.test(value)
}
const rules: FormRules = {
  email: [
    {
      required: true,
      message: t('Messages.EmailRequired')
    },
    {
      validator: validateEmail,
      trigger: 'blur',
      message: t('Messages.EmailFails')
    }
  ],
  password: [
    {
      required: true,
      message: t('Messages.PasswordRequired')
    },
    {
      min: 5,
      trigger: 'input',
      message: t('Messages.PasswordMinLength', { min: 5 })
    }
  ]
};

async function login(e: MouseEvent) {
  e.preventDefault();
  loading.value = true;
  try {
    await formRef.value?.validate();
    modelRef.value.button = 'login'
    try {
      const response = await api.post('Account/Login', { json: modelRef.value });
      window.location.href = response.url;
    }
    catch (e) {
      message.error(t('Messages.InvalidCredentials'));
    }
  }
  catch {

  }
  loading.value = false;
};

</script>
<template>
  <NForm @keyup.enter="login" size="large" ref="formRef" :show-label="false" :model="modelRef" :rules="rules">
    <NGrid cols="2" item-responsive responsive="self" x-gap="24">
      <NFormItemGi span="2" path="email">
        <NInput v-model:value="modelRef.email"  type='text' :input-props="{ type: 'email', id: 'email', autocomplete: 'on' }" @keydown.enter.prevent :placeholder="t('Placeholders.Login.email')" />
      </NFormItemGi>
      <NFormItemGi span="2" path="password">
        <NInput v-model:value="modelRef.password" type='password' :input-props="{ type: 'password', id: 'password', autocomplete: 'on' }" @keydown.enter.prevent :placeholder="t('Placeholders.Login.password')" />
      </NFormItemGi>
      <NFormItemGi span="2">
        <NCheckbox v-model:checked="modelRef.rememberLogin">{{ t('Placeholders.Login.rememberLogin') }}</NCheckbox>
      </NFormItemGi>
      <NFormItemGi span="2">
        <NButton :block=true type="success" @click="login">{{ t('Placeholders.Login.btnLogin') }}</NButton>
      </NFormItemGi>
    </NGrid>
  </NForm>
</template>
