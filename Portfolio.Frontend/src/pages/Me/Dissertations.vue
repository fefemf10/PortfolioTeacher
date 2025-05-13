<script setup lang="ts">
  import { NButton, NDataTable, NIcon, useDialog, useMessage, NForm, NFormItem, NSelect, NSpace, NModal, NInput, NInputNumber  } from 'naive-ui';
  import { Dissertation } from '@/classes/Dissertation';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import MyNCard from '@/components/MyNCard.vue';
  import { useI18n } from 'vue-i18n';
  import { DissertationType } from '@/enums/DissertationType';
  import { useEnumLocalization } from '@/EnumLocalization';
  import { guid } from '@/oidc';
  import { Trash as TrashIcon, Plus as PlusIcon, PencilAlt as PencilIcon } from '@vicons/fa';
  const {t} = useI18n();
  const { localizeEnum } = useEnumLocalization();
  const dialog = useDialog();
  const message = useMessage()
  const data = ref<Dissertation[]>([]);
  const showModal = ref(false);
  interface DissertationForm {
    id?: string;
    yearProtection: number | null;
    type: DissertationType | null;
    specialization: string;
    topic: string;
  }
  const currentDissertation = ref<DissertationForm>({
    yearProtection: null,
    type: null,
    specialization: '',
    topic: ''
  });
  const loading = ref(false);
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Dissertations.DataColumns.0'),
        key: 'yearProtection'
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.1'),
        key: 'type',
        render: (row: Dissertation) => localizeEnum(row.type, DissertationType, 'Dissertation')
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.2'),
        key: 'specialization'
      },
      {
        title: t('Pages.Resume.Dissertations.DataColumns.3'),
        key: 'topic'
      },
      {
        key: 'actions',
        width: 120,
        render: (row: Dissertation) => h('div', { style: 'display: flex; gap: 5px;' }, [
          h(NButton, {
            size: 'small',
            type: 'primary',
            onClick: () => handleEdit(row)
          }, { default: () => h(NIcon, { component: PencilIcon }) }),
          h(NButton, {
            size: 'small',
            type: 'error',
            onClick: () => handleDelete(row.id)
          }, { default: () => h(NIcon, { component: TrashIcon }) })
        ])
      }
  ]);
  const handleAdd = () => {
    currentDissertation.value = {
      yearProtection: new Date().getFullYear(),
      type: 1,
      specialization: '',
      topic: ''
    };
    showModal.value = true;
  };
  const handleEdit = (dissertation: Dissertation) => {
    currentDissertation.value = { ...dissertation };
    showModal.value = true;
  };
  const handleDelete = async (id: string) => {
    dialog.warning({
      title: t('Common.ConfirmDelete'),
      positiveText: t('Common.Delete'),
      negativeText: t('Common.Cancel'),
      onPositiveClick: async () => {
        try {
          await api.delete(`api/teacher/${await guid()}/dissertation/${id}`);
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
    if (!currentDissertation.value) return;

    loading.value = true;
    try {
      if (currentDissertation.value.id) {
        const { id, ...dissertationWithoutId } = currentDissertation.value;
        await api.put(`api/teacher/${await guid()}/dissertation/${id}`, { json: dissertationWithoutId });
        data.value = data.value.map(item => item.id === id ? new Dissertation({ ...currentDissertation.value }) : item);
        message.success(t('Common.UpdatedSuccessfully'));
      } else {
        const response = await api.post(`api/teacher/${await guid()}/dissertation`, { json: currentDissertation.value }).json<string>();
        currentDissertation.value.id = response;
        data.value = [...data.value, new Dissertation({ ...currentDissertation.value })];
        message.success(t('Common.AddedSuccessfully'));
      }
      showModal.value = false;
    } catch (error) {
      message.error(t(currentDissertation.value.id ? 'Common.UpdateError' : 'Common.AddError'));
      console.error('Error saving dissertation:', error);
    } finally {
      loading.value = false;
    }
  };
  const getTypeOptions = () => {
    return Object.keys(DissertationType)
      .filter(key => isNaN(Number(key)) && key !== "None") // Фильтруем числовые ключи
      .map(key => ({
        label: localizeEnum(DissertationType[key], DissertationType, 'Dissertation'),
        value: DissertationType[key]
      }));
  };

  onMounted(async () => {
    data.value = await api.get<Dissertation[]>(`api/teacher/${await guid()}/dissertation`).json();
  });
</script>
<template>
  <MyNCard :title="t('Pages.Resume.Dissertations.CardTitle')">
    <template #header-extra>
      <NButton type="primary" @click="handleAdd">
        <NIcon size="large" :component="PlusIcon" />
      </NButton>
    </template>
    <NDataTable :columns="columns" :data="data" bordered />
    <NModal v-model:show="showModal" preset="dialog" :title="currentDissertation?.id ? t('Common.Edit') : t('Common.Add')">
      <NForm>
        <NFormItem :label="t('Pages.Resume.Dissertations.DataColumns.0')">
          <NInputNumber v-model:value="currentDissertation.yearProtection" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Dissertations.DataColumns.1')">
          <NSelect v-model:value="currentDissertation.type" :options="getTypeOptions()" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Dissertations.DataColumns.2')">
          <NInput v-model:value="currentDissertation.specialization" />
        </NFormItem>

        <NFormItem :label="t('Pages.Resume.Dissertations.DataColumns.3')">
          <NInput v-model:value="currentDissertation.topic" />
        </NFormItem>
      </NForm>

      <template #action>
        <NSpace justify="end">
          <NButton @click="showModal = false">{{ t('Common.Cancel') }}</NButton>
          <NButton type="primary" :loading="loading" @click="submitForm">{{ currentDissertation?.id ? t('Common.Save') : t('Common.Add') }}</NButton>
        </NSpace>
      </template>
    </NModal>
  </MyNCard>
</template>
