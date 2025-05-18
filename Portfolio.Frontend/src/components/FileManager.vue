<template>
  <div class="file-manager">
    <n-upload
      multiple
      :action="uploadUrl"
      :headers="headers"
      :data="uploadData"
      @finish="handleUploadFinish"
      @error="handleUploadError"
    >
      <n-button>Upload Files</n-button>
      <template #tip>
        <div style="margin-top: 8px; color: #888">
          Click or drag files to upload
        </div>
      </template>
    </n-upload>

    <n-divider />

    <n-list bordered>
      <n-list-item v-for="file in files" :key="file.id">
        <template #prefix>
          <n-icon :component="FileOutline" />
        </template>
        <n-thing :title="file.name" :description="formatFileSize(file.size)">
          <template #header-extra>
            <n-space>
              <n-button
                text
                type="primary"
                @click="downloadFile(file)"
              >
                Download
              </n-button>
              <n-button
                text
                type="error"
                @click="deleteFile(file)"
              >
                Delete
              </n-button>
            </n-space>
          </template>
          <div>Uploaded: {{ formatDate(file.uploadedAt) }}</div>
        </n-thing>
      </n-list-item>
    </n-list>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { NUpload, NButton, NList, NListItem, NThing, NSpace, NDivider, NIcon, useNotification } from 'naive-ui'
import { FileTrayOutline as FileOutline } from '@vicons/ionicons5'
import api from '@/api' // Импортируем вашу обёртку ky

// Notification system
const notification = useNotification()

// API endpoints (замените на ваши реальные эндпоинты)
const uploadUrl = '/api/upload' // Используем относительный путь
const filesUrl = '/api/files'
const deleteUrl = id => `/api/files/${id}`

// Дополнительные данные для загрузки
const uploadData = {
  folder: 'user-uploads'
}

// Заголовки (ваша обёртка уже добавляет Authorization)
const headers = {}

// Список файлов
const files = ref([])

// Загружаем файлы при монтировании компонента
onMounted(() => {
  fetchFiles()
})

// Форматирование размера файла
const formatFileSize = (bytes) => {
  if (bytes === 0) return '0 Bytes'
  const k = 1024
  const sizes = ['Bytes', 'KB', 'MB', 'GB']
  const i = Math.floor(Math.log(bytes) / Math.log(k))
  return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i]
}

// Форматирование даты
const formatDate = (dateString) => {
  return new Date(dateString).toLocaleString()
}

// Получение списка файлов
const fetchFiles = async () => {
  try {
    const response = await api.get(filesUrl).json()
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
  try {
    const response = JSON.parse(event?.target?.responseText)
    if (response.success) {
      notification.success({
        title: 'Успех',
        content: `${file.name} успешно загружен`,
        duration: 3000
      })
      fetchFiles() // Обновляем список файлов
    } else {
      notification.error({
        title: 'Ошибка загрузки',
        content: response.message || 'Неизвестная ошибка',
        duration: 3000
      })
    }
  } catch (error) {
    notification.error({
      title: 'Ошибка',
      content: 'Не удалось обработать ответ сервера',
      duration: 3000
    })
  }
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
const downloadFile = async (file) => {
  try {
    // Получаем blob файла
    const blob = await api.get(file.downloadUrl || `${filesUrl}/${file.id}/download`, {
      headers: {
        'Accept': 'application/octet-stream'
      }
    }).blob()

    // Создаем временную ссылку для скачивания
    const url = window.URL.createObjectURL(blob)
    const a = document.createElement('a')
    a.href = url
    a.download = file.name
    document.body.appendChild(a)
    a.click()
    window.URL.revokeObjectURL(url)
    document.body.removeChild(a)
  } catch (error) {
    notification.error({
      title: 'Ошибка',
      content: error.message || 'Не удалось скачать файл',
      duration: 3000
    })
  }
}

// Удаление файла
const deleteFile = async (file) => {
  try {
    await api.delete(deleteUrl(file.id))

    notification.success({
      title: 'Успех',
      content: `${file.name} успешно удалён`,
      duration: 3000
    })

    fetchFiles() // Обновляем список файлов
  } catch (error) {
    notification.error({
      title: 'Ошибка',
      content: error.message || 'Не удалось удалить файл',
      duration: 3000
    })
  }
}
</script>

<style scoped>
.file-manager {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}
</style>
