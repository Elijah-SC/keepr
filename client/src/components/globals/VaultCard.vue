<script setup>
import { Vault } from "@/models/Vault.js";

defineProps({
  vault: { type: Vault, required: true }
})
</script>


<template>
  <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }" title="See Vault Page">
    <div class="Vault-Card my-3 w-100">
      <img :src="vault.img" alt="Vault-Img" class="w-100 rounded h-100">
      <h4 class="marko-one-regular Vault-Name">{{ vault.name }}</h4>
      <i v-if="vault.isPrivate" class="fs-3 mdi mdi-shield-lock-outline Vault-Lock" title="Private Vault"></i>
    </div>
  </router-link>
</template>


<style lang="scss" scoped>
.Vault-Card {
  width: 21vw;
  height: 21vh;
  object-fit: cover;
  object-position: center;
  position: relative;
}

.Vault-Name {
  position: absolute;
  bottom: 0;
  left: 0;
  margin-bottom: 3px;
  margin-left: 3px;
  text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.975);
  font-size: 1.15em;
  color: rgb(255, 255, 255);
}

.Vault-Lock {
  position: absolute;
  top: 0;
  right: 0;
  margin: 5px;
  text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.975);
  font-size: 1.15em;
  color: rgb(255, 255, 255);

}

.Vault-Img {
  object-fit: cover;
  object-position: center;
}
</style>