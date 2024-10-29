<script setup>
import { AppState } from "@/AppState.js";
import { accountService } from "@/services/AccountService.js";
import { keepsService } from "@/services/KeepsService.js";
import Pop from "@/utils/Pop.js";
import { ref, watch } from "vue";

const formData = ref({
  name: '',
  picture: '',
  coverImg: ''
})

watch(() => AppState.account, () => {
  formData.value = { ...AppState.account }
}, { immediate: true })



async function updateAccount() {
  try {
    await accountService.updateAccount(formData.value)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div class="bg-primary">
    <form @submit.prevent="updateAccount()" class="p-3" action="">
      <div class="mb-3">
        <label for="Name" class="form-label">Name</label>
        <input v-model="formData.name" type="text" class="form-control" id="exampleFormControlInput1"
          placeholder="Name.." required minlength="1" maxlength="100">
      </div>
      <div class="mb-3">
        <label for="Img" class="form-label">CoverImg Url</label>
        <input v-model="formData.coverImg" type="text" class="form-control" id="ImgInput" placeholder="CoverImg Url.."
          required minlength="1" maxlength="1000">
      </div>
      <div class="mb-3">
        <label for="Pictures" class="form-label">Picture Url</label>
        <input v-model="formData.picture" class="form-control" id="Picture" placeholder="Picture...." required
          maxlength="1000" minlength="1">
      </div>
      <div class="w-100 text-end">
        <button class="btn btn-warning" type="submit">Update</button>
      </div>
    </form>
  </div>

</template>


<style lang="scss" scoped>
form {
  color: rgba(128, 128, 128, 0.644);
}
</style>