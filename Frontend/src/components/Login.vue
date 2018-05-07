<template>
  <div>
    <el-form label-position="right" label-width="100px" :model="form">
      <el-form-item label="Email">
        <el-input v-model="form.email"></el-input>
      </el-form-item>
      <el-form-item label="Mot de passe">
        <el-input v-model="form.password"></el-input>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
  export default
  {
    name: "Login",
    data()
    {
      return {
        form:
        {
          email: "",
          password: ""
        }
      }
    }
  }
</script>

<style scoped>

</style>