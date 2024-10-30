<script setup>
import { Keep } from "@/models/Keep.js";
import Pop from "@/utils/Pop.js";
import { keepsService } from "@/services/KeepsService.js";
import { AppState } from "@/AppState.js";
import { computed } from "vue";
import ProfilePicture from "../ProfilePicture.vue";
import { vaultKeepsService } from "@/services/VaultKeepsService.js";

const account = computed(() => AppState.account)
const activeVault = computed(() => AppState.activeVault)

const props = defineProps({
  keep: { type: Keep, required: true }
})


async function getKeepById() {
  try {
    await keepsService.getKeepById(props.keep.id);
  }
  catch (error) {
    Pop.error(error);
  }
}

async function deleteKeep() {
  try {
    const confirm = await Pop.confirm("Are you sure you want to Keep this keep")
    if (!confirm) return
    await keepsService.deleteKeep(props.keep.id)
  }
  catch (error) {
    Pop.error(error);
  }
}
async function deleteVaultKeep() {
  try {
    const confirm = await Pop.confirm("Are you sure you want to Remove this Keep from your Vault")
    if (!confirm) return
    await vaultKeepsService.deleteVaultKeep(props.keep.vaultKeepId)
  }
  catch (error) {
    Pop.error(error);
  }
}

const authorizedUser = computed(() => {
  if (!account.value) return false
  if (props.keep.creatorId != account.value?.id) return false
  return true
})

const vaultCreator = computed(() => {
  if (!activeVault.value) return false
  if (activeVault.value.creator.id != account.value?.id) return false
  return true
})
</script>


<template>
  <div @click="getKeepById()" class="Parent">
    <img :src="keep.img" alt="keep Img" class="rounded w-100" data-bs-toggle="modal" data-bs-target="#Keep-Modal"
      title="See Keep details">
    <span @click="deleteVaultKeep()" role="button" v-if="vaultCreator && keep.vaultKeepId != null" class="delete"><i
        class="fs-3 mdi mdi-close-circle-outline" title="Remove From Vault"></i></span>
    <span @click="deleteKeep()" role="button" v-else-if="authorizedUser" class="delete"><i class="mdi mdi-delete"
        title="delete Keep"></i></span>
    <p class="marko-one-regular text-light Child text-start">{{ keep.name }}</p>
    <ProfilePicture :profile="keep.creator" class="profile-pic" />
  </div>
</template>


<style lang="scss" scoped>
.Parent {
  position: relative;
  cursor: pointer;
}

img {
  width: 21vw;
  object-fit: cover;
  object-position: center;
}

.Child {
  margin-bottom: unset;
  position: absolute;
  bottom: 0;
  left: 0;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.737);
  font-size: 1.15em;
  display: inline-block;
  width: 70%;
  margin: 5px;
}

.profile-pic {
  position: absolute;
  bottom: 0;
  right: 0;
  text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.737);
  font-weight: 500;
  height: 2.5em;
  width: 2.5em;
  border-radius: 50%;
  margin: 5px;
}

.delete {
  position: absolute;
  top: 0;
  right: 0;
  color: red;
  margin-right: 3px;
}

@media screen and (max-width: 992px) {
  .profile-pic {
    height: 1.6em;
    width: 1.6em;
  }
}

@media screen and (max-width: 768px) {
  img {
    width: 27vw;
  }

  .Child {
    font-size: 1em;
  }

  .profile-pic {
    height: 1.5em;
    width: 1.5em;
    right: 5%;
  }
}

@media screen and (max-width: 576px) {
  img {
    width: 40vw;
  }

  .profile-pic {
    display: none;
  }
}
</style>