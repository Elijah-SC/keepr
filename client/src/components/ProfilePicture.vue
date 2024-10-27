<script setup>
import { Profile } from "@/models/Profile.js";

defineProps({
  profile: { type: Profile, required: true }
})
</script>


<template>
  <img :src="profile.picture" :alt="profile.name" :title="profile.name + `'s picture`">
</template>


<style lang="scss" scoped>
img {
  object-fit: cover;
  object-position: center;
}
</style>