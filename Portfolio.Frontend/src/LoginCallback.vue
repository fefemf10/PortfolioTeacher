<script setup lang="ts">
import { onMounted, ref, watchEffect } from 'vue';
import { useRouter } from 'vue-router';
import userManager, { guid, isUserCreated, userCreated } from './oidc';
import api from './api';

const router = useRouter();
onMounted(() => {
  userManager.signinRedirectCallback().then(async () => {
    if (!isUserCreated()) {
      let response;
      try{
        response = await api.get('api/teacher/' + await guid());
        if (response.ok) {
          window.localStorage.setItem('user_api_created', 'true')
          userCreated.value = true;
          router.replace({ path: '/' });
        }
      }
      catch{
          window.localStorage.setItem('user_api_created', 'false')
          userCreated.value = false;
          router.replace({ path: '/registration' });
      }
    }
    else
      router.replace({ path: '/' });
  });
});
</script>

<template>
  <div>
    <p>Completing login...</p>
  </div>
</template>
