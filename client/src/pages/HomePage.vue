<script setup>
import { AppState } from "@/AppState.js";
import KeepCard from "@/components/globals/KeepCard.vue";
import { Keep } from "@/models/Keep.js";
import { keepsService } from "@/services/KeepsService.js";
import Pop from "@/utils/Pop.js";
import { computed, onMounted } from "vue";

const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getAllKeeps()
}
)

async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps();
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <section class="container-fluid">
    <div class="row mt-5 justify-content-around">
      <div class="col-11">
        <div class="masonry-container text-center">
          <div class="mb-3" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keep="keep" />
          </div>

        </div>
      </div>
    </div>

  </section>
</template>

<style scoped lang="scss">
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

.Keep-box {}
</style>
