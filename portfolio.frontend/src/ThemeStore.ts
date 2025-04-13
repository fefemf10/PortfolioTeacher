import { ref, computed, watchEffect } from 'vue'
import { useOsTheme, darkTheme, lightTheme } from 'naive-ui'

const THEME_KEY = 'user-theme'
const saved = localStorage.getItem(THEME_KEY) as 'system' | 'light' | 'dark' | null
const themePreference = ref<'system' | 'light' | 'dark'>(saved || 'system')

const osTheme = useOsTheme()

const effectiveTheme = computed(() => {
  return themePreference.value === 'system' ? osTheme.value : themePreference.value
})

const naiveTheme = computed(() => {
  return effectiveTheme.value === 'dark' ? darkTheme : lightTheme
})

watchEffect(() => {
  localStorage.setItem(THEME_KEY, themePreference.value)
})

watchEffect(() => {
  const themeColor = effectiveTheme.value === 'dark' ? '#000000' : '#ffffff';
  const metaThemeColor = document.querySelector('meta[name="theme-color"]') as HTMLMetaElement
  if (metaThemeColor) {
    metaThemeColor.setAttribute('content', themeColor)
  } else {
    const meta = document.createElement('meta')
    meta.name = 'theme-color'
    meta.content = themeColor
    document.head.appendChild(meta)
  }
});

export function useThemeStore() {
  return {
    themePreference,
    effectiveTheme,
    naiveTheme,
  }
}
