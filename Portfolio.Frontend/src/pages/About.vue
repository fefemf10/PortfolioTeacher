<script setup lang="ts">
  import { NFlex, NCard } from 'naive-ui'
  import NavMenu from '../components/NavMenu.vue';
</script>
<template>
  <NFlex justify="center" vertical>
    <!-- <UserInfo :user=user></UserInfo> -->
    <NavMenu></NavMenu>
    <NCard class="cards" title="Образование">
      <template #footer>
        #footer
      </template>
    </NCard>
  </NFlex>
</template>
<style scoped>
  .cards{
    border-radius: 0.5rem;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.09);
  }
</style>
