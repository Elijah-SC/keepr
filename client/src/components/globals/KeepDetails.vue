<script setup>
import { AppState } from "@/AppState.js";
import { keepsService } from "@/services/KeepsService.js";
import { computed } from "vue";

const Keep = computed(() => AppState.activeKeep);
const account = computed(() => AppState.account)
</script>


<template>
  <section v-if="Keep" class="container-fluid bg-secondary rounded">
    <div class="row">
      <div class="col-md-6 media-width">
        <img :src="Keep.img" alt="keep Img">
      </div>
      <div class="col-md-6 flex-grow-1 d-flex flex-column justify-content-between align-items-center media-width">
        <div class="d-flex justify-content-between p-3 w-100">
          <div></div>
          <div>
            <span class="mx-2 fs-5 header"><i class="mdi mdi-eye" title="Keep views"></i> {{ Keep.views }}</span>
            <span class="mx-2 fs-5 header"><i class="mdi mdi-alpha-k-box-outline" title="Keep saves"></i> {{ Keep.kept
              }}</span>
          </div>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"
            title="Close Keep Details"></button>
        </div>
        <div class="text-center px-5">
          <h2 class="mb-3">{{ Keep.name }}</h2>
          <p>{{ Keep.description }}</p>
        </div>
        <div class="d-flex p-2 w-100 align-items-center justify-content-between">
          <div v-if="account" class="ms-2">
            <Button class="btn btn-warning text-dark">Save</Button>
          </div>
          <div v-else></div>
          <div class="me-2 d-flex align-items-center">
            <ProfilePicture :profile="Keep.creator" class="picture" />
            <p class="mb-0 ms-2 md-invisible">{{ Keep.creator.name }}</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped>
img {
  width: 100%;
  height: 100%;
  max-height: 80vh;
  border-top-left-radius: 4px;
  border-bottom-left-radius: 4px;
  object-fit: cover;
  object-position: center;
}

.header {
  color: gray;
}

.picture {
  height: 50px;
  width: 50px;
  border-radius: 50%;
}

@media screen and (max-width: 992px) {

  .md-invisible {
    display: none;
  }
}

@media screen and (max-width: 768px) {

  .media-width {
    width: 100%;
  }

  img {
    border-radius: 4px;
  }
}

.col-md-6 {
  padding: unset;
}
</style>