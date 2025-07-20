<script setup lang="ts">
import api from '@/api';
import { FormInst, FormRules, NForm, NFormItemGi, NGrid, NInput, NButton, NCheckbox, FormItemInst, FormItemRule, useMessage } from 'naive-ui';
import { ref } from 'vue';
import { useI18n } from 'vue-i18n';
import { useRoute } from 'vue-router';
const route = useRoute();
const { t } = useI18n();
const message = useMessage()
interface RegistrationModel {
  email: string | null;
  password: string | null;
  confirmPassword: string | null;
}
const formRef = ref<FormInst | null>(null);
const confirmPasswordFormItemRef = ref<FormItemInst | null>(null)
const modelRef = ref<RegistrationModel>({
  email: null,
  password: null,
  confirmPassword: null,
});
function validateEmail(rule: FormItemRule, value: string): boolean {
  return /^\S+@\S+\.\S+$/.test(value)
}
function validatePasswordStartWith(rule: FormItemRule, value: string): boolean {
  return (
    !!modelRef.value.password
    && modelRef.value.password.startsWith(value)
    && modelRef.value.password.length >= value.length
  )
}

function validatePasswordSame(rule: FormItemRule, value: string): boolean {
  return value === modelRef.value.password
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
  ],
  confirmPassword: [
    {
      required: true,
      message: t('Messages.ConfirmPasswordRequired'),
      trigger: ['input', 'blur']
    },
    {
      validator: validatePasswordStartWith,
      message: t('Messages.ConfirmPasswordFails'),
      trigger: 'input'
    },
    {
      validator: validatePasswordSame,
      message: t('Messages.ConfirmPasswordFails'),
      trigger: ['blur', 'password-input']
    }
  ]
};
async function handlePasswordInput() {
  if (modelRef.value.confirmPassword) {
    try {
      await confirmPasswordFormItemRef.value?.validate({ trigger: 'password-input' })
    }
    catch {

    }
  }
}
async function register(e: MouseEvent) {
  e.preventDefault();
  try {
    await formRef.value?.validate();
    try {
      const response = await api.post('Account/Register', { json: { email: modelRef.value?.email, password: modelRef.value?.password, returnUrl: route.query?.ReturnUrl, button: 'register' } });
      if (response.ok)
        window.location.href = response.url;
    } catch (e) {
      message.error(t('Messages.InvalidCredentials'));
    }
  }
  catch {

  }
};
</script>
<template>
  <NForm size="large" ref="formRef" :show-label="false" :model="modelRef" :rules="rules">
    <NGrid cols="2" item-responsive responsive="self" x-gap="24">
      <NFormItemGi span="2" path="email">
        <NInput v-model:value="modelRef.email" :input-props="{ type: 'email', id: 'email', autocomplete: 'on' }" @keydown.enter.prevent :placeholder="t('Placeholders.Register.email')"/>
      </NFormItemGi>
      <NFormItemGi span="2" path="password">
        <NInput v-model:value="modelRef.password" type='password' :input-props="{ type: 'password', id: 'password', autocomplete: 'on' }" @input="handlePasswordInput" @keydown.enter.prevent :placeholder="t('Placeholders.Register.password')"/>
      </NFormItemGi>
      <NFormItemGi span="2" ref="confirmPasswordFormItemRef" path="confirmPassword">
        <NInput v-model:value="modelRef.confirmPassword" type='password' :input-props="{ type: 'password', id: 'confirmPassword', autocomplete: 'on' }" :disabled="!modelRef.password" @keydown.enter.prevent :placeholder="t('Placeholders.Register.confirmPassword')"/>
      </NFormItemGi>
      <NFormItemGi span="2">
        <NButton :block=true type="success" @click="register">{{ t('Placeholders.Register.btnRegister') }}</NButton>
      </NFormItemGi>
    </NGrid>
  </NForm>
</template>
