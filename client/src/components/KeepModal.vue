<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)

</script>


<template>
    <div class="modal fade " data-bs-backdrop="static" data-bs-keyboard="false" id="keepModal" tabindex="-1"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered">
            <!-- CONTENT START -->
            <div class="modal-content container-fluid" v-if="keep">
                <div class="row">
                    <div class="col-6 p-0 modalImg" :style="{ backgroundImage: `url(${keep.img})` }">
                    </div>
                    <div class="col-6 p-2">
                        <div class="text-end m-0">
                            <button type="button" class="btn-close text-end" data-bs-dismiss="modal"
                                aria-label="Close"></button>
                        </div>
                        Hi!
                    </div>
                </div>
            </div>
            <!-- CONTENT END -->
        </div>
    </div>
</template>


<style lang="scss" scoped>
.modalImg {
    background-position: center;
    background-size: cover;
    aspect-ratio: 1/1;
}
</style>