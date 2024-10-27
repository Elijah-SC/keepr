<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import ModalWrapper from "./components/globals/ModalWrapper.vue";
import KeepDetails from "./components/KeepDetails.vue";

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-secondary">
    <router-view />
  </main>
  <ModalWrapper modal-id="Keep-Modal">
    <KeepDetails />
  </ModalWrapper>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
