<script setup>
import { Keep } from "@/models/Keep.js";
import { Profile } from "@/models/Profile.js";
import ProfilePicture from "../ProfilePicture.vue";
import Pop from "@/utils/Pop.js";
import { keepsService } from "@/services/KeepsService.js";

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
</script>


<template>
  <div class="Parent">
    <img @click="getKeepById()" :src="keep.img" alt="keep Img" class="rounded" data-bs-toggle="modal"
      data-bs-target="#Keep-Modal" title="See Keep details">
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
  bottom: 5px;
  left: 6%;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.737);
  font-size: 1.15em;
  display: inline-block;
  width: 70%;
}

.profile-pic {
  position: absolute;
  bottom: 5px;
  right: 4%;
  text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.737);
  font-weight: 500;
  height: 2.5em;
  width: 2.5em;
  border-radius: 50%;
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