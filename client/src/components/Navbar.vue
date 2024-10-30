<script setup>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { AppState } from "@/AppState.js";
import { useRoute } from "vue-router";

const theme = ref(loadState('theme') || 'light')
const account = computed(() => AppState.account)
const route = useRoute();

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

</script>

<template>
  <nav class="marko-one-regular navbar navbar-expand-sm navbar-light bg-secondary px-3 mt-2 pb-3 bb">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <Button class="btn btn-info">Home</Button>
      </div>
    </router-link>
    <div v-if="account && route.name == 'Home' || route.name == 'Account'">
      <div class="dropdown">
        <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu">
          <li><a data-bs-toggle="modal" data-bs-target="#Keep-Form" class="dropdown-item" href="#">New Keep</a></li>
          <li><a data-bs-toggle="modal" data-bs-target="#Vault-Form" class="dropdown-item" href="#">New Vault</a></li>
        </ul>
      </div>
    </div>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-between" id="navbarText">
      <div></div>
      <div>
        <img src="/public/img/Keepr-logo.svg" alt="Keepr Logo" title="Logo">
      </div>
      <!-- LOGIN COMPONENT HERE -->
      <div class="text-end d-flex align-items-center">
        <div>
        </div>
        <Login title="Account Options" />
      </div>
    </div>
  </nav>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}

.bb {
  box-shadow: 0px 1px 0px var(--bs-success);
}
</style>
