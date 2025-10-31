<script setup>
import { Keep } from '@/models/Keep.js';
import { keepService } from '@/services/KeepService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';


defineProps({
    keep: { type: Keep, required: true }
})

async function getActiveKeep(keepId) {
    try {
        await keepService.getActiveKeep(keepId)
    }
    catch (error) {
        Pop.error(error);
        logger.error(error)
    }
}

</script>


<template>
    <div :style="{ backgroundImage: `url(${keep.img})` }"
        class="keep-card card shadow text-white justify-content-end d-flex selectable" @click="getActiveKeep(keep.id)"
        data-bs-toggle="modal" data-bs-target="#keepModal">
        <div class=" col-md-6 mx-2">
            <p>{{ keep.name }}</p>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.keep-card {
    height: 40dvh;
    background-size: cover;
    background-position: center;
}

p {
    font-family: 'Marko One', sans-serif;
    font-weight: 600;
    font-style: normal;
    text-shadow: 0 2px 4px rgba(0, 0, 0, 0.6);
}

@media (max-width: 900px) {
    .keep-card {
        height: 20dvh;
    }
}
</style>