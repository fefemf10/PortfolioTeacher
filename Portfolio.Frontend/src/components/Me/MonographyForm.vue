<script setup lang="ts">
  import api from '@/api';
  import { Monography, TeacherShortNameInfo } from '@/classes/Publication';
  import { UserFile } from '@/classes/UserFile';
  import { PublicationType } from '@/enums/PublicationType';
  import { guid } from '@/oidc';
  import {  useDialog, useMessage, NForm, NFormItem, NSpace, NModal, NInput, NInputNumber, NButton } from 'naive-ui'
  import { ref } from 'vue';
  import { useI18n } from 'vue-i18n';
  const {t} = useI18n();
  const dialog = useDialog();
  const message = useMessage()
  const showModal = ref(false);
  const loading = ref(false);
  interface Form {
    id?: string;
    name: string | null;
    publicationType: PublicationType | null;
    yearPublication: number | null;
    coAuthors: TeacherShortNameInfo[];
    files: UserFile[];
    publisher?: string | null;
    circulation: number | null;
    countPages: number | null;
  }
  const currentForm = ref<Form>({
    name: null,
    yearPublication: null,
    publicationType: PublicationType.Monography,
    coAuthors: [],
    files: [],
    publisher: null,
    circulation: null,
    countPages: null
  });
  const data = defineModel<Monography[]>('data');
  const handleAdd = () => {
    currentForm.value = {
      name: null,
      yearPublication: new Date().getFullYear(),
      publicationType: PublicationType.Monography,
      coAuthors: [],
      files: [],
      publisher: null,
      circulation: null,
      countPages: null
    };
    showModal.value = true;
  };
  const handleEdit = (formValue: Monography) => {
    currentForm.value = { ...formValue };
    showModal.value = true;
  };
  const handleDelete = async (id: string) => {
    dialog.warning({
      title: t('Common.ConfirmDelete'),
      positiveText: t('Common.Delete'),
      negativeText: t('Common.Cancel'),
      onPositiveClick: async () => {
        try {
          await api.delete(`api/teacher/${await guid()}/publication/${id}`);
          data.value = data.value.filter(item => item.id !== id);
          message.success(t('Common.DeletedSuccessfully'));
        } catch (error) {
          message.error(t('Common.DeleteError'));
          console.error('Error deleting dissertation:', error);
        }
      }
    });
  };
  const submitForm = async () => {
    if (!currentForm.value) return;

    loading.value = true;
    const formData = {
      ...currentForm.value,
      coAuthors: currentForm.value.coAuthors.map(author => author.id)
    };
    try {
      if (currentForm.value.id) {
        const { id, ...withoutId } = formData;
        await api.put(`api/teacher/${await guid()}/publication/monography/${id}`, { json: withoutId });
        data.value = data.value.map(item => item.id === id ? new Monography({ ...currentForm.value }) : item);
        message.success(t('Common.UpdatedSuccessfully'));
      } else {
        const response = await api.post(`api/teacher/${await guid()}/publication/monography`, { json: formData }).json<string>();
        currentForm.value.id = response;
        data.value = [...data.value, new Monography({ ...currentForm.value })];
        message.success(t('Common.AddedSuccessfully'));
      }
      showModal.value = false;
    } catch (error) {
      message.error(t(currentForm.value.id ? 'Common.UpdateError' : 'Common.AddError'));
      console.error('Error saving dissertation:', error);
    } finally {
      loading.value = false;
    }
  };
  defineExpose({
    handleAdd,
    handleEdit,
    handleDelete
  });
</script>

<template>
  <NModal v-model:show="showModal" preset="dialog" :title="currentForm?.id ? t('Common.Edit') : t('Common.Add')">
      <NForm>
        <NFormItem :label="t('Pages.Resume.Monographies.DataColumns.1')">
          <NInput v-model:value="currentForm.name" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Monographies.DataColumns.2')">
          <NInput v-model:value="currentForm.publisher" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Monographies.DataColumns.3')">
          <NInputNumber v-model:value="currentForm.yearPublication" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Monographies.DataColumns.4')">
          <NInputNumber v-model:value="currentForm.circulation" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Monographies.DataColumns.5')">
          <NInputNumber v-model:value="currentForm.countPages" />
        </NFormItem>
      </NForm>

      <template #action>
        <NSpace justify="end">
          <NButton @click="showModal = false">{{ t('Common.Cancel') }}</NButton>
          <NButton type="primary" :loading="loading" @click="submitForm">{{ currentForm?.id ? t('Common.Save') : t('Common.Add') }}</NButton>
        </NSpace>
      </template>
    </NModal>
</template>
