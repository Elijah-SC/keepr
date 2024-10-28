<script setup>
import { keepsService } from "@/services/KeepsService.js";
import Pop from "@/utils/Pop.js";
import { ref } from "vue";

const formData = ref({
  name: '',
  description: '',
  img: ''
})



async function createKeep() {
  try {
    await keepsService.createKeep(formData.value)
    formData.value = {
      name: '',
      description: '',
      img: ''
    }
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div class="bg-primary">
    <form @submit.prevent="createKeep()" class="p-3" action="">
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
      <div class="w-100 text-end">
        <button class="btn btn-warning" type="submit">Create</button>
      </div>
    </form>
  </div>

</template>


<style lang="scss" scoped>
form {
  color: rgba(128, 128, 128, 0.644);
}

textarea {
  height: 25vh;
}
</style>