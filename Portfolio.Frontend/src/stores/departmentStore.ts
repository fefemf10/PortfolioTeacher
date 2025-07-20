import { Department } from "@/classes/Department.js";
import { defineStore } from "pinia";
import { computed, ref } from "vue";
import api from '@/api.js';

export const useDepartmentStore = defineStore('department', () => {
  const departments = ref<Department[]>([]);

  const getDepartmentById = computed(() => {
    // Создаем Map для быстрого доступа
    const departmentMap = new Map<string, Department>();

    // Рекурсивная функция для индексации
    const indexDepartments = (dept: Department) => {
      departmentMap.set(dept.id, dept);
      dept.childDepartments.forEach(child => indexDepartments(child));
    };

    // Индексируем все департаменты
    departments.value.forEach(dept => indexDepartments(dept));

    // Возвращаем функцию поиска
    return (id: string): Department | undefined => departmentMap.get(id);
  });
  const getChildDepartments = computed(() => (parentId: string) =>
    departments.value.filter(dept => dept.parentDepartmentId === parentId)
  );

  async function fetchDepartments() {
    departments.value = await api.get('api/department').json<Department[]>();
  }
  return { departments, getDepartmentById, getChildDepartments, fetchDepartments }
})
