<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

const account = computed(() => AppState.account)

</script>

<template>
  <section class="container-fluid">
    <div v-if="account" class="row justify-content-center">
      <div class="col-10 text-center mt-3 Parent">
        <img :src="account.coverImg" alt="account Cover Img" class="w-100">
        <div class="Child">
          <img class="profile-pic" :src="account.picture" alt="" />
          <h1 class="mt-2 marko-one-regular">{{ account.name }}</h1>
        </div>
      </div>
      <div class="text-center">

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

.Parent {
  position: relative;
}

.Child {
  position: absolute;
  bottom: -29%;
}

@media screen and (max-width: 576px) {
  .Child {
    bottom: -35%;
  }
}

@media screen and (max-width: 370px) {
  .Child {
    bottom: -40%;
  }
}

@media screen and (max-width: 340px) {
  .Child {
    bottom: -50%;
  }
}
</style>
