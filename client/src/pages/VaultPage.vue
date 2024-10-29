<script setup>
import { AppState } from "@/AppState.js";
import KeepCard from "@/components/globals/KeepCard.vue";
import { vaultsService } from "@/services/VaultService.js";
import Pop from "@/utils/Pop.js";
import { computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";

onMounted(() => {
  getVaultById();
})
const route = useRoute();
const router = useRouter();
const activeVault = computed(() => AppState.activeVault);
const keeps = computed(() => AppState.keepsInVault);
const account = computed(() => AppState.account)


async function getVaultById() {
  try {
    await vaultsService.getVaultById(route.params.vaultId)
    getKeepsForVault();
  }
  catch (error) {
    Pop.error(error);
    if (error.response.data == "invalid Credentials") {
      router.push({ name: 'Home' })
    }
  }
}

async function getKeepsForVault() {
  try {
    await vaultsService.getKeepsForVault(route.params.vaultId)
  }
  catch (error) {
    Pop.error(error);
  }
}
async function deleteVault() {
  try {
    const confirm = await Pop.confirm("Are you sure you want to delete this Vault")
    if (!confirm) return
    await vaultsService.deleteVault(activeVault.value.id)
    Pop.toast("Vault Deleted")
    router.push({ name: 'Account' })
  }
  catch (error) {
    Pop.error(error);
  }
}

const authorizedUser = computed(() => {
  if (!account.value) return false
  if (activeVault.value.creator.id != account.value.id) return false
  return true
})

const keepOrKeeps = keeps.value?.length == 1 ? "Keep" : "Keeps";
</script>


<template>
  <section v-if="activeVault && keeps" class="container-fluid">
    <div class="row justify-content-around">
      <div class="col-7 p-0">
        <div class="parent mt-2">
          <img :src="activeVault.img" alt="Vault Img" class="w-100 rounded">
          <div class="marko-one-regular text-center child w-100">
            <h1 class="mb-0">{{ activeVault.name }}</h1>
            <h5 class="mb-0">By {{ activeVault.creator.name }}</h5>
          </div>
        </div>
        <div class="text-center w-100">
          <div class="d-flex justify-content-between">
            <h3 class="text-start mb-0">Description</h3>
            <div class="dropdown-center">
              <button v-if="authorizedUser" class="btn btn-secondary" type="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                ...
              </button>
              <ul class="dropdown-menu">
                <li><a @click="deleteVault()" class="dropdown-item">Delete Vault</a></li>
              </ul>
            </div>
          </div>
          <h5>{{ activeVault.description }}</h5>
        </div>
      </div>
    </div>
    <div class="row justify-content-center mt-3">
      <div class="col-md-4 col-xl-2">
        <div class="text-center">
          <h3 class="rounded-pill pill mb-0 p-2">{{ keeps?.length }} {{ keepOrKeeps }}</h3>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="masonry-container text-center my-3">
          <div class="mb-3" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
.parent {
  position: relative;
}

.child {
  position: absolute;
  bottom: 0;
  margin-bottom: 5px;
  color: white;
  text-shadow: 2px 2px 2px black;
  background-color: rgba(128, 128, 128, 0.436);
  backdrop-filter: blur(5px);
}

.pill {
  background-color: rgba(120, 85, 246, 0.436);
  backdrop-filter: blur(5px);
  color: white;
  text-shadow: 2px 2px 3px black;
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

.dropdown {
  display: inline-block;
  height: 5px;
}
</style>