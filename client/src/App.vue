<script setup>
import Navbar from './components/Navbar.vue';
import ModalWrapper from "./components/globals/ModalWrapper.vue";
import KeepForm from "./components/globals/KeepForm.vue";
import VaultForm from "./components/globals/VaultForm.vue";
import KeepDetails from "./components/globals/KeepDetails.vue";

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-secondary">
    <router-view />
  </main>
  <ModalWrapper modal-id="Keep-Modal" size="modal-xl" position="modal-dialog-centered">
    <KeepDetails />
  </ModalWrapper>
  <ModalWrapper modal-id="Keep-Form" :HideHeader="false" title="Add Your Keep" size="" position="">
    <KeepForm />
  </ModalWrapper>
  <ModalWrapper modal-id="Vault-Form" :HideHeader="false" title="Add Your Vault" size="" position="">
    <VaultForm />
  </ModalWrapper>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
