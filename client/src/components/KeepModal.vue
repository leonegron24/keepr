<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)
const identity = computed(() => AppState.identity)

</script>


<template>
    <div class="modal fade " data-bs-backdrop="static" data-bs-keyboard="false" id="keepModal" tabindex="-1"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered">
            <!-- CONTENT START -->
            <div class="modal-content container-fluid" v-if="keep">
                <div class="row">
                    <div class="col-md-6 p-0 modalImg" :style="{ backgroundImage: `url(${keep.img})` }">
                    </div>
                    <div class="col-md-6 p-2 d-flex flex-column">
                        <!-- Top content stays at the top -->
                        <div class="text-end w-100">
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>

                        <div class="row justify-content-center mb-3">
                            <div class="col-6 text-center">
                                <div class="d-flex justify-content-around">
                                    <i class="mdi mdi-eye"><span>0</span></i>
                                    <div>
                                        <p class="bordered-text">k</p> <span>0</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Spacer to take remaining space -->
                        <div class="mt-auto mb-auto d-flex flex-column justify-content-center align-items-center">
                            <h1 class="text-center">{{ keep.name }}</h1>
                            <div>{{ keep.description }}</div>
                        </div>
                        <div v-if="account" class="row mt-4 d-flex justify-content-between">
                            <div class="d-flex col-4  justify-content-between align-items-center">
                                <div>Vault Names</div>
                                <btn class="btn btn-sm p-0 btn-grey">SAVE</btn>
                            </div>
                            <div v-if="account?.picture || identity?.picture" class="col-4 text-end">
                                <img :src="account?.picture || identity?.picture" alt="account photo" height="40"
                                    class="user-img" />
                            </div>
                        </div>
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

div {
    font-family: 'Marko One', sans-serif;
    font-weight: 400;
    font-style: normal;
}

.bordered-text {
    display: inline-block;
    /* makes the box fit the text width */
    border: 2px solid #333;
    /* border color & thickness */
    border-radius: 12px;
    /* rounded corners */
    padding: 2px 4px;
    line-height: 1;
}

.user-img {
    height: 50px;
    width: 50px;
    border-radius: 100px;
    object-fit: cover;
    object-position: center;
}
</style>