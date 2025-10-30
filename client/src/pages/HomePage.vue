<script setup>
import Example from '@/components/Example.vue';
import Login from '@/components/Login.vue';


</script>

<template>
  <header>
    <div class="row justify-content-end shadow">


      <!-- TITLE and Login -->
      <div class="col-md-6 justify-content-between d-flex align-items-center">
        <RouterLink :to="{ name: 'Home' }" class="m-2 text-black text-decoration-none">
          <div class="bordered-text">
            <p class="m-0">the<br>keepr<br>co.</p>
          </div>
        </RouterLink>

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
