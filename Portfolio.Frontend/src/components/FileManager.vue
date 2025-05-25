<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { NText, NUpload, NButton, NList, NListItem, NThing, NSpace, NFlex, NIcon, useNotification, useDialog, buttonProps } from 'naive-ui'
import { FileTrayOutline as FileOutline } from '@vicons/ionicons5'
import api from '@/api' // Импортируем вашу обёртку ky
import { UserFile } from '@/classes/UserFile'
import userManager, { guid } from '@/oidc'
import { useRoute } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { FileType } from '@/enums/FileType'
const props = defineProps<{
  loading: boolean
}>();
const route = useRoute();
// Notification system
const notification = useNotification()
const dialog = useDialog();
const { t } = useI18n();
const url = ref<string>('');
const headers = ref<Record<string, string>>({});
// Дополнительные данные для загрузки
const uploadData = {}
// Список файлов
const files = ref<UserFile[]>([])
const pButtonProps = ref({
  loading: false
});
// Загружаем файлы при монтировании компонента
onMounted(async () => {
  url.value = `api/publication/${route.params.eid}/files`;
  headers.value = {
    'Authorization': `Bearer ${(await userManager?.getUser()).access_token}`
  };
  await fetchFiles();
})

// Форматирование размера файла
const formatFileSize = (bytes) => {
  if (bytes === 0) return '0 Bytes'
  const k = 1024
  const sizes = ['Bytes', 'KB', 'MB', 'GB']
  const i = Math.floor(Math.log(bytes) / Math.log(k))
  return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i]
}

// Получение списка файлов
async function fetchFiles() {
  try {
    const response = await api.get(url.value).json<UserFile[]>();
    files.value = response
  } catch (error) {
    notification.error({
      title: 'Ошибка',
      content: error.message || 'Не удалось загрузить список файлов',
      duration: 3000
    })
  }
}
// Обработка успешной загрузки
const handleUploadFinish = ({ file, event }) => {
  const response = JSON.parse(event?.target?.responseText)
  if (response.id !== null) {
    files.value = [...files.value, response];
    notification.success({title: 'Успех', content: `${file.name} успешно загружен`, duration: 3000})
  } else
    notification.error({title: 'Ошибка загрузки', content: response.message || 'Неизвестная ошибка', duration: 3000})
  return file
}

// Обработка ошибки загрузки
const handleUploadError = ({ file, event }) => {
  notification.error({
    title: 'Ошибка загрузки',
    content: `Не удалось загрузить файл ${file.name}`,
    duration: 3000
  })
  return file
}

// Скачивание файла
const downloadFile = async (file: UserFile) => {
  try {
    // Получаем blob файла
    const blob = await api.get(`${url.value}/${file.id}`, {
      headers: {
        'Accept': 'application/octet-stream'
      }
    }).blob()

    const a = document.createElement('a')
    a.href = window.URL.createObjectURL(blob)
    a.download = file.name
    document.body.appendChild(a)
    a.click()
    window.URL.revokeObjectURL(url.value)
    document.body.removeChild(a)
  } catch (error) {
    notification.error({title: 'Ошибка', content: 'Не удалось скачать файл', duration: 3000})
  }
}

// Удаление файла
const deleteFile = async (file) => {
  dialog.warning({
    title: t('Common.ConfirmDelete'),
    positiveText: t('Common.Delete'),
    negativeText: t('Common.Cancel'),
    positiveButtonProps: pButtonProps.value,
    onPositiveClick: async () => {
      try {
        pButtonProps.value.loading = true;
        const response = await api.delete(`${url.value}/${file.id}`);
        notification.success({title: 'Успех', content: `${file.name} успешно удалён`, duration: 3000});
        files.value = files.value.filter(item => item.id !== file.id);
      }
      catch {
        notification.error({ title: 'Ошибка', content: 'Не удалось удалить файл', duration: 3000});
      }
      finally {
        pButtonProps.value.loading = false;
      }
    }
  });
}
</script>

<template>
  <div>
    <NUpload v-if="loading" multiple :show-file-list=false :action="'/' + url" :headers="headers" :data="uploadData"
      @finish="handleUploadFinish" @error="handleUploadError">
      <NButton>{{ t('Common.UploadFiles') }}</NButton>
    </NUpload>

    <NList v-if="files.length > 0" bordered class="file-manager">
      <NListItem v-for="file in files" :key="file.id">
        <template #prefix>
          <NFlex justify="center" align="center" size="small">
            <NIcon :component="FileOutline" size="24" />
            <NButton size="tiny" type="warning" strong>{{FileType[file.fileType]}}</NButton>
          </NFlex>
        </template>
        <NThing :title="file.name">
          <template #description>
            <NSpace>
              <NText>{{ formatFileSize(file.size) }}</NText>
              <NButton text type="primary" @click="downloadFile(file)">{{ t('Common.Download') }}</NButton>
              <NButton v-if="loading" text type="error" @click="deleteFile(file)">{{ t('Common.Delete') }}</NButton>
            </NSpace>
            <!-- <div>Uploaded: {{ formatDate(file.) }}</div> -->
          </template>
        </NThing>
      </NListItem>
    </NList>
  </div>
</template>

<style scoped></style>
