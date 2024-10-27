<script setup>
defineProps({
  modalId: { type: String, required: true },
  HideHeader: { type: Boolean, default: true },
  title: { type: String, default: 'Modal Title' }
})


</script>


<template>

  <!-- Modal -->
  <div class="modal fade" :id="modalId" tabindex="-1" :aria-labelledby="modalId + 'Label'" aria-hidden="true">
    <div class="modal-dialog  modal-dialog-centered modal-xl">
      <div class="modal-content">
        <div v-if="!HideHeader" class="modal-header">
          <h1 class="modal-title fs-5" :id="modalId + 'Label'"></h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body p-0">
          <slot></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>