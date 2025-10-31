<script setup>
import { AppState } from '@/AppState.js';
import Example from '@/components/Example.vue';
import KeepCards from '@/components/KeepCards.vue';
import KeepModal from '@/components/KeepModal.vue';
import Login from '@/components/Login.vue';
import { keepService } from '@/services/KeepService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getKeeps()
})

async function getKeeps() {
  try {
    await keepService.getKeeps()
  }
  catch (error) {
    Pop.error(error);
    logger.error("[Could not fetch Recipe!]", error.message)
  }
}

</script>

<template>
  <div class="position-relative">
    <header class="mb-3 position-relative shadow mobile-header">
      <div class="d-flex align-items-center justify-content-between p-3">

        <!-- Left: Home & Create Buttons -->
        <div class="d-flex align-items-center">
          <!-- Home Button -->
          <RouterLink :to="{ name: 'Home' }" class="me-3 text-black mobileButton">
            <h3 class="bordered-text border border-secondary bg-secondary m-0 px-3 py-1">
              Home
            </h3>
          </RouterLink>

          <!-- Create Button -->
          <a class="text-decoration-none text-black btn py-2 px-3" data-bs-toggle="collapse" aria-controls="navbarText"
            aria-expanded="false" aria-label="Toggle navigation" data-bs-target="#create-options">
            <h3 class="m-0 d-flex align-items-center">
              Create <span class="ms-2"><i class="mdi mdi-menu-down"></i></span>
            </h3>
          </a>
        </div>
        <div class="collapse navbar-collapse " id="create-options">
          <ul class="navbar-nav">
            <li>
              <div>
                <btn class="btn-sm btn border-success mx-2">new keep</btn>
                <btn class="btn-sm btn border-danger">new vault</btn>
              </div>
            </li>
          </ul>
        </div>

        <!-- Center: Title -->
        <div class="position-absolute start-50 translate-middle-x text-center">
          <RouterLink :to="{ name: 'Home' }" class="text-black text-decoration-none">
            <div class="bordered-text px-3 py-1">
              <p class="m-0">the<br>keepr<br>co.</p>
            </div>
          </RouterLink>
        </div>

        <!-- Right: Login/Profile -->
        <div class="d-flex align-items-center">
          <Login />
        </div>

      </div>
    </header>

    <body class="container-fluid">
      <div class="row">
        <div class="col-md-3 col-6 mb-4" v-for="keep in keeps" :key="keep.id">
          <KeepCards :keep="keep" />
        </div>
        <KeepModal />
      </div>
    </body>
    <footer class="position-relative"></footer>
  </div>
</template>

<style scoped lang="scss">
.bordered-text {
  display: inline-block;
  /* makes the box fit the text width */
  border: 2px solid #333;
  /* border color & thickness */
  border-radius: 12px;
  /* rounded corners */
  padding: 4px 8px;
  line-height: 1;
}

header {
  font-family: 'Marko One', sans-serif;
  font-weight: 400;
  font-style: normal;
}

@media (max-width: 767px) {
  .mobile-header {
    position: fixed;
    bottom: 0;
    width: 100%;
    z-index: 9999;
    background-color: #fff;
  }

  @media (max-width: 767px) {
    h3 {
      font-size: 1rem;
      /* smaller text */
      padding: 2px 6px;
      /* smaller padding */
    }

    .mobileButton {
      display: none;
    }
  }


}
</style>
