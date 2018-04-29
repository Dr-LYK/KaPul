<template>
  <div>
    <div v-if="connected">
      <p>Connected</p>
    </div>
    <div v-else>
      <p>Not connected</p>
    </div>
  </div>
</template>

<script>
  export default
  {
    props: ["connected"]
  }

</script>

<style scoped>

</style>