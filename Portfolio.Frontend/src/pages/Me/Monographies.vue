<script setup lang="ts">
  import { NButton, NDataTable, NIcon, NGrid, NText, NGi} from 'naive-ui';
  import { computed, h, onMounted, ref } from 'vue';
  import api from '@/api';
  import { RouterLink, useRoute } from 'vue-router';
  import MyNCard from '@/components/MyNCard.vue';
  import ActionButtons from '@/components/Me/ActionButtons.vue';
  import { useI18n } from 'vue-i18n';
  import { Monography } from '@/classes/Publication';
  import { guid } from '@/oidc';
  import { Plus as PlusIcon } from '@vicons/fa';
  import MonographyForm from '@/components/Me/MonographyForm.vue';
  import MonographyDetails from '@/components/MonographyDetails.vue';
  import router from '@/Router';
  const route = useRoute();
  const {t} = useI18n();
  const data = ref<Monography[]>([]);
  const monographyFormRef = ref<InstanceType<typeof MonographyForm>>();
  const columns = computed(() => [
      {
        title: t('Pages.Resume.Monographies.DataColumns.0'),
        key: 'coAuthors',
        render: (row: Monography) => {
          return row.coAuthors?.map(coAuthor => {
            const fullName = `${coAuthor.lastName} ${coAuthor.firstName} ${coAuthor.middleName}`;
            return h(
              RouterLink,
              {
                to: `/resume/${coAuthor.id}`
              },
              { default: () => fullName }
            );
          });
        }
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.1'),
        key: 'name'
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.2'),
        key: 'publisher'
      },
      {
        title: t('Pages.Resume.Monographies.DataColumns.3'),
        key: 'yearPublication'
      },
      {
        key: 'actions',
        width: 120,
        render: (row: Monography) => h(ActionButtons<Monography>, {
          row,
          onEdit: handleEdit,
          onDelete: handleDelete
        })
      }
  ]);
  const handleAdd = () => {
    monographyFormRef.value?.handleAdd();
  };
  const handleEdit = (formValue: Monography) => {
    monographyFormRef.value?.handleEdit(formValue);
  };
  const handleDelete = (id:string) => {
    monographyFormRef.value?.handleDelete(id);
  };
  const selected = computed<Monography>(() => {
    return data.value.find(e => e.id === route.params.eid);
  });
  onMounted(async () => {
    data.value = await api.get<Monography[]>(`api/teacher/${await guid()}/publication/monography`).json();
  });
  const rowProps = (row: Monography) => ({
    style: {
      cursor: 'pointer',
    },
    onClick: () => {
      router.push(`/me/monographies/${row.id}`);
    }
  });
</script>
<template>
  <MyNCard v-if=!route.params.eid :title="t('Pages.Resume.Monographies.CardTitle')">
    <template #header-extra>
      <NButton type="primary" @click="handleAdd">
        <NIcon size="large" :component="PlusIcon" />
      </NButton>
    </template>
    <NDataTable :columns="columns" :data="data" bordered :row-props="rowProps" />
    <MonographyForm ref="monographyFormRef" v-model:data="data"></MonographyForm>
  </MyNCard>
  <MonographyDetails v-if="route.params.eid && selected" :selected="selected" :loading="true"></MonographyDetails>
  <MyNCard v-if="route.params.eid && !selected" title="Такой монографии нет">

  </MyNCard>
</template>
