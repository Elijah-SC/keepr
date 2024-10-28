<script setup>
import { vaultsService } from "@/services/VaultService.js";
import Pop from "@/utils/Pop.js";
import { ref } from "vue";


const formData = ref({
  name: '',
  description: '',
  img: '',
  isPrivate: false
})


async function createVault() {
  try {
    await vaultsService.createVault(formData.value)
    formData.value = {
      name: '',
      description: '',
      img: '',
      isPrivate: false
    }
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <div class="bg-primary">
    <form @submit.prevent="createVault()" class="p-3" action="">
      <div class="mb-3">
        <label for="Img" class="form-label">Img Url</label>
        <input v-model="formData.img" type="text" class="form-control" id="ImgInput" placeholder="Img Url..">
      </div>
      <div class="mb-3">
        <label for="Name" class="form-label">Name</label>
        <input v-model="formData.name" type="text" class="form-control" id="exampleFormControlInput1"
          placeholder="Name..">
      </div>
      <div class="mb-3">
        <label for="Description" class="form-label">Description</label>
        <textarea v-model="formData.description" class="form-control" id="DescriptionTextarea" rows="3"
          placeholder="Description...."></textarea>
      </div>
      <div class="w-100 d-flex justify-content-end">
        <div>
          <div>
            <small class="mb-0">Private Vaults can only be seen by you</small>
            <div class="d-flex justify-content-around">
              <input v-model="formData.isPrivate" type="checkbox" class="check-box">
              <p class="fs-5 mb-0">Make Vault Private?</p>
            </div>
          </div>
          <button class="btn btn-warning w-100 mt-1 text-light fw" type="submit">Create Vault</button>
        </div>
      </div>
    </form>
  </div>
</template>


<style lang="scss" scoped>
.check-box {
  width: 25px;
  aspect-ratio: 1/1;
  outline: unset;
}

.fw {
  font-weight: 500;
}
</style>