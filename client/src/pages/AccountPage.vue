<script setup>
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js';
import Pop from "@/utils/Pop.js";
import { vaultsService } from "@/services/VaultService.js";
import { accountService } from "@/services/AccountService.js";
import VaultCard from "@/components/globals/VaultCard.vue";


onMounted(() => {
  getAccountVaults()
  getAccountKeeps()
})

const account = computed(() => AppState.account)
watch(() => account.value, getAccountKeeps)

const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

async function getAccountVaults() {
  try {
    await accountService.getAccountVaults()
  }
  catch (error) {
    Pop.error(error);
  }
}
async function getAccountKeeps() {
  try {
    await accountService.clearGhostData()
    if (!account.value) return
    await accountService.getAccountKeeps(account.value.id)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <section class="container-fluid">
    <div v-if="account" class="row justify-content-center">
      <div class="col-11 text-center mt-3 p-0">
        <img :src="account.coverImg" alt="account Cover Img" class="w-100 cover-img">
        <div class="w-100">
          <img class="profile-pic" :src="account.picture" alt="profile picture" />
          <div class="d-flex justify-content-center align-items-center">
            <h1 class="mt-2 marko-one-regular">{{ account.name }}</h1>
            <div class="dropdown-center text-end">
              <button v-if="account" class="btn btn-secondary" type="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                ...
              </button>
              <ul class="dropdown-menu">
                <li><a data-bs-toggle="modal" data-bs-target="#Account-Modal" class="dropdown-item">Edit Account</a>
                </li>
              </ul>
            </div>
          </div>
          <h4>{{ vaults?.length }} Vaults | {{ keeps?.length }} Keeps</h4>
        </div>
        <div class="text-start">
          <h1 class="marko-one-regular mt-3">Vaults</h1>
          <div class="row">
            <div v-for="vault in vaults" :key="vault.id" class="col-sm-4 col-md-3">
              <VaultCard :vault="vault" />
            </div>
          </div>

        </div>
        <div class="text-start">
          <h1 class="marko-one-regular mt-3">Keeps</h1>
        </div>
        <div class="masonry-container text-center">
          <div class="mb-3" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keep="keep" />
          </div>

        </div>
      </div>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </section>
</template>

<style scoped lang="scss">
.profile-pic {
  width: 20%;
  aspect-ratio: 1/1;
  object-position: center;
  object-fit: cover;
  border-radius: 50%;
  box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.46);
}

.cover-img {
  max-height: 70vh;
  object-fit: cover;
  object-position: center;
  margin-bottom: -13%;
}


.masonry-container {
  columns: 4;
}


@media screen and (max-width: 768px) {
  .masonry-container {
    columns: 3;
  }
}

@media screen and (max-width: 576px) {
  .masonry-container {
    columns: 2;
  }
}
</style>
