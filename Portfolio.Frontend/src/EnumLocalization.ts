import { useI18n } from 'vue-i18n'
export function useEnumLocalization() {
  const { t } = useI18n()
  const localizeEnum = (value: number, enumObject: any, groupKey: string) => {
    const key = enumObject[value];
    return t(`Enums.${groupKey}.${key}`);
  }
  return { localizeEnum }
}
