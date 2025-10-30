<script setup>
import Example from '@/components/Example.vue';
import Login from '@/components/Login.vue';


</script>

<template>
  <header class="position-relative shadow">
    <div class="d-flex align-items-center justify-content-between p-3">

      <!-- Left: Home & Create Buttons -->
      <div class="d-flex align-items-center">
        <!-- Home Button -->
        <RouterLink :to="{ name: 'Home' }" class="me-3 text-black">
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
</style>
