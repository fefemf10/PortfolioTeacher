import { defineStore } from "pinia";
import { computed, ref } from "vue";
import api from '@/api.js';
import { guid, role, isAuthenticated as oidcIsAuthenticated } from "@/oidc.js";
import { UserProfile } from "@/classes/UserProfile.js";
import { hashCode } from "@/hashCode.js";

export const useUserStore = defineStore('user', () => {
  const user = ref<UserProfile>(null);
  const isAdmin = ref<boolean>(false);
  const isAuthenticated = ref<boolean>(false);
  const urlAvatar = ref<string>(null);
  const isUserCreatedOnAPI = computed(() => {
    return user.value !== null;
  })
  async function updateAvatar() {
    if (user.value != null) {
      urlAvatar.value = `/images/id/AV${hashCode(user.value.id) % 100}.png`;
      if (user.value.avatar != null)
      {
        const timestamp = new Date().getTime();
        urlAvatar.value = `/api/user/${user.value.id}/avatar?${timestamp}`;
      }
    }
  }
  async function fetchUserProfile() {
    if (await oidcIsAuthenticated()) {
      isAdmin.value = await role() === 'Administrator';
      isAuthenticated.value = true;
      if (!isAdmin.value) {
        user.value = await api.get<UserProfile>('api/teacher/' + await guid()).json<UserProfile>();
        await updateAvatar();
      }
    }
  }

  function unloadUserProfile() {
    user.value = null;
    isAdmin.value = false;
    isAuthenticated.value = false;
  }

  return { user, isAuthenticated, isAdmin, urlAvatar, fetchUserProfile, isUserCreatedOnAPI, unloadUserProfile, updateAvatar }
})
