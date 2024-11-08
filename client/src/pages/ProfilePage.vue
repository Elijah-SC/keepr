<script setup>
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js';
import Pop from "@/utils/Pop.js";
import { vaultsService } from "@/services/VaultService.js";
import { accountService } from "@/services/AccountService.js";
import VaultCard from "@/components/globals/VaultCard.vue";
import { Profile } from "@/models/Profile.js";
import { profileService } from "@/services/ProfileService.js";
import { useRoute, useRouter } from "vue-router";
import KeepCard from "@/components/globals/KeepCard.vue";


onMounted(() => {
  getUserProfile()
})

const profile = computed(() => AppState.ActiveProfile)
const account = computed(() => AppState.account)
watch(() => profile.value, getAccountKeeps)
const route = useRoute()
const router = useRouter()

const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.ProfileVaults)

async function getUserProfile() {
  try {
    await profileService.getUserProfile(route.params.profileId)
    checkIfProfileIsUser()
  }
  catch (error) {
    Pop.error(error);
  }
}

function checkIfProfileIsUser() {
  if (account.value?.id == profile.value.id) {
    router.push({ name: "Account" })
  }
  getProfileVaults()
  getAccountKeeps()
}


async function getProfileVaults() {
  try {
    await accountService.getProfileVaults(route.params.profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}
async function getAccountKeeps() {
  try {
    await accountService.clearGhostData()
    if (!profile.value) return
    await accountService.getAccountKeeps(profile.value.id)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <section class="container-fluid">
    <div v-if="profile" class="row justify-content-center">
      <div class="col-11 text-center mt-3">
        <img :src="profile.coverImg" alt="account Cover Img" class="w-100 cover-img">
        <div class="w-100">
          <img class="profile-pic" :src="profile.picture" alt="" />
          <h1 class="mt-2 marko-one-regular">{{ profile.name }}</h1>
          <h4>{{ vaults?.length }} Vaults | {{ keeps?.length }} Keeps</h4>
        </div>
        <div class="text-start">
          <h1 class="marko-one-regular mt-3">Vaults</h1>
          <div class="row">
            <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
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

.Parent {
  position: relative;
}

.Child {
  position: absolute;
  top: 75%;
  margin: auto;
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
